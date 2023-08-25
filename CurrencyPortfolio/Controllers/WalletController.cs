using BL.Commands.WalletItems;
using BL.DTOs;
using BL.Queries.Wallet;
using BL.Queries.Wallets;
using BL.Utilities.Calculetors;
using CurrencyPortfolio.Utilites.Validators.Wallet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetWallet")]
        public async Task<IActionResult> GetWallet(Guid UserId)
        {
            var wallet = await _mediator.Send(new GetWalletQuery() { Id = UserId });
            if (wallet == null)
            {
                return NotFound(UserId);
            }
            return Ok(wallet);
        }

        [HttpGet("GetWalletStatistics")]
        public async Task<IActionResult> GetWalletStatistics(Guid UserId)
        {
            var wallet = await _mediator.Send(new GetWalletQuery() { Id = UserId});
            if (wallet == null)
            {
                return NotFound(UserId);
            }
            var res = await UserStatisticsCalculator.GetMainStatistics(wallet);
            return Ok(res);
        }

        [HttpGet("RecomendationList")]
        public async Task<IActionResult> RecomendationList()
        {
            var res = await UserStatisticsCalculator.GetRecomenddationsList();
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
             
        [HttpPost("AddWalletItem")]
        public async Task<IActionResult> AddWalletItem(CreateWalletItemCommand walletItem)
        {
            CreatWalletItemCommandValidator validations = new CreatWalletItemCommandValidator();
            var res = await validations.ValidateAsync(walletItem);
            if (!res.IsValid)
            {
                List<ErrorDTO> errors = new List<ErrorDTO>();
                foreach (var item in res.Errors)
                {
                    errors.Add(new ErrorDTO() { ErrorMessage = item.ErrorMessage, PropertyName = item.PropertyName });
                }
                return BadRequest(errors);
            }

            await _mediator.Send(walletItem);
            return Ok();
        }

        [HttpDelete("RemoveWalletItem")]
        public async Task<IActionResult> RemoveWalletItem(DeleteWalletItemCommand walletItemCommand)
        {
            DeleteWalletItemCommandValidator validationRules = new();
            var res = validationRules.Validate(walletItemCommand);
            if (!res.IsValid)
            {
                List<ErrorDTO> errors = new List<ErrorDTO>();
                foreach (var item in res.Errors)
                {
                    errors.Add(new ErrorDTO() { ErrorMessage = item.ErrorMessage, PropertyName = item.PropertyName });
                }
                return BadRequest(errors);
            }
            await _mediator.Send(walletItemCommand);
            return Ok();
        }

        [HttpGet("Transactions")]
        public async Task<IActionResult> GetTransactions(Guid userId)
        {
            var transactions = await _mediator.Send(new GetWalletTransactionsQuery() { UserId = userId });
            return Ok(transactions);
        }
    }
}
