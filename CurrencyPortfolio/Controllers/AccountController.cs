using BL.Commands.Users;
using BL.DTOs;
using BL.DTOs.UserDTOs;
using BL.Queries.User;
using BL.Queries.Users;
using BL.Utilities.PasswordHelper;
using CurrencyPortfolio.Utilites.JwtToken;
using CurrencyPortfolio.Utilites.Validators.User;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        IConfiguration _configuration;
        UserValidator _validator;
        IMediator _mediator;

        public AccountController(IConfiguration configuration, IMediator mediator)
        {
           
            _configuration = configuration;
            _validator = new UserValidator();
            _mediator = mediator;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromForm] CreateUserDTO userDto)
        {
            var validationRes = _validator.Validate(userDto);
            if (validationRes.IsValid)
            {

                if (await _mediator.Send(new GetUserByEmailQuery() { Email = userDto.Email}) == null)
                {
                    CreateUserCommand userCommand = new CreateUserCommand()
                    {
                        UserName = userDto.UserName,
                        Email = userDto.Email,
                        Password = userDto.Email,
                        CondirmPassword = userDto.CondirmPassword
                    };

                    await _mediator.Send(userCommand);

                    return Ok();
                }

                return BadRequest(new ErrorDTO() { ErrorMessage = "this email is already taken", PropertyName = "Email" });

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


        public async Task<IActionResult> Login([FromBody] LogInUserDTO user)
        {
            var User = await _mediator.Send(new GetUserByNameQuery() { UserName = user.UserName});

            if (User == null)
            {
                return Unauthorized();
            }

            if (!PasswordHelper.VerifyPassword(user.Password, User.HashPassword, User.SlatPassword))
            {
                return Unauthorized();
            }


            var token = JwtTokenHelper.CreateToken(User, _configuration);
            return Ok(token);
        }
    }
}
