using Microsoft.AspNetCore.Mvc;
using TestTask.Domain;
using AutoMapper;
using TestTask.Application.Coins.Command.CreateCoin;
using TestTask.Application.Coins.Command.DeleteCoin;
using TestTask.Application.Coins.Command.UpdateCoin;
using TestTask.Application.Coins.Queries.GetCoinList;
using TestTask.Application.Coins.Queries.GetCoin;


namespace TestTask.WebApi.Controllers
{
    [Route("products/[controller]/[action]")]
    public class CoinController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoinLookupDto>>> GetAllCoin(int? value)
        {
            var query = new GetCoinListQuery
            {
                Value = value
            };
            var vm = await Mediator.Send(query);
            List<CoinLookupDto> coins = new List<CoinLookupDto>();
            foreach (var coin in vm.Coins)
            {
                coins.Add(coin);
            }
            return Ok(coins);
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetCoin(int id)
        {
            var query = new GetCoinQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Coin>> CreateCoin([FromBody] CreateCoinCommand createCoinCommand)
        {
            if (createCoinCommand.Value<0)
            {
                return BadRequest(createCoinCommand.Value);
            }
            else if (createCoinCommand.Quantity<0)
            {
                return BadRequest(createCoinCommand.Quantity);
            }
            else
            {
                var coin = await Mediator.Send(createCoinCommand);
                return Ok(coin);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Coin>> UpdateCoin([FromBody] UpdateCoinCommand updateCoinCommand)
        {
            if (updateCoinCommand.Value < 0)
            {
                return BadRequest(updateCoinCommand.Value);
            }
            else if (updateCoinCommand.Quantity < 0)
            {
                return BadRequest(updateCoinCommand.Quantity);
            }
            else
            {
                var coin = await Mediator.Send(updateCoinCommand);
                return Ok(coin);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoin(int id)
        {
            var command = new DeleteCoinCommand
            {
                Id = id
            };
            var coinId = await Mediator.Send(command);
            return Ok(coinId);
        }

    }
}
