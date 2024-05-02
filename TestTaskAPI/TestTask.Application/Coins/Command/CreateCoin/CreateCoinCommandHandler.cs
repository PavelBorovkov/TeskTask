using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Application.Products.Command.CreateProduct;
using TestTask.Domain;

namespace TestTask.Application.Coins.Command.CreateCoin
{
    public class CreateCoinCommandHandler :
        IRequestHandler<CreateCoinCommand, int>
    {
        private readonly ITestTaskDbContext _DbContext;
        public CreateCoinCommandHandler(ITestTaskDbContext dbContext) =>
            _DbContext = dbContext;
        public async Task<int> Handle(CreateCoinCommand request,
            CancellationToken cancellationToken)
        {
            var coin = new Coin
            {
                Value = request.Value,
                Quantity = request.Quantity,
                Access = request.Access
            };
            await _DbContext.Coins.AddAsync(coin, cancellationToken);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return coin.Id;
        }
    }
}
