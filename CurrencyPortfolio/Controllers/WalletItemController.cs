using BL.Commands.WalletItems;
using BL.Commands.Wallets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddWalletItemBalace")]
        public async Task<IActionResult> AddWalletItemBalace(AddWalletItemBalanceCommand command)
        {
            await _mediator.Send(command);
            await _mediator.Send(new AddTransactionCommand()
            {
                walletItemId = command.walletItemId,
                AddedBalance = command.AddedAmount * command.buyPrice,
                buyPrice = command.buyPrice,
                ItemName = command.Name,
                Date = DateTime.UtcNow,
            }
            );
            return Ok();
        }

        [HttpPost("SubtractWalletItemBalance")]
        public async Task<IActionResult> SubtractWalletItemBalance(SubtractWalletItemBalanceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
