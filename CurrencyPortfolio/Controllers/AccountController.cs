using AutoMapper;
using BL.Commands.Users;
using BL.DTOs;
using BL.DTOs.UserDTOs;
using BL.Queries.User;
using BL.Utilities.PasswordHelper;
using CurrencyPortfolio.Utilites.JwtToken;
using CurrencyPortfolio.Utilites.Validators.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CurrencyPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        IConfiguration _configuration;
        UserValidator _validator;
        IMediator _mediator;
        IMapper _mapper;

        public AccountController(IConfiguration configuration, IMediator mediator, IMapper mapper)
        {

            _configuration = configuration;
            _validator = new UserValidator();
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(CreateUserDTO userDto)
        {
            var validationRes = _validator.Validate(userDto);
            if (validationRes.IsValid)
            {

                if (await _mediator.Send(new GetUserByEmailQuery() { Email = userDto.Email }) == null)
                {

                    var user = _mapper.Map<CreateUserCommand>(userDto);

                    await _mediator.Send(user);

                    return Ok();
                }

                return BadRequest(new ErrorDTO() { ErrorMessage = "This email is already taken", PropertyName = "Email" });

            }
            List<ErrorDTO> errorDtos = new List<ErrorDTO>();
            foreach (var error in validationRes.Errors)
            {
                ErrorDTO errorDto = new ErrorDTO()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                };
                errorDtos.Add(errorDto);
            }
            return BadRequest(errorDtos);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LogInUserDTO user)
        {
            var User = await _mediator.Send(new GetUserByNameQuery() { UserName = user.UserName });

            if (User == null)
            {
                return Unauthorized("Incorrect UserName or Password");
            }

            if (!PasswordHelper.VerifyPassword(user.Password, User.HashPassword, User.SlatPassword))
            {
                return Unauthorized("Incorrect UserName or Password");
            }


            var token = JwtTokenHelper.CreateToken(User, _configuration);

            Log.Information($"{User.UserName} is logged", user);

            return Ok(new TokenDTO() { Token = token, UserId = User.Id, UserName = User.UserName});
        }
    }
}
