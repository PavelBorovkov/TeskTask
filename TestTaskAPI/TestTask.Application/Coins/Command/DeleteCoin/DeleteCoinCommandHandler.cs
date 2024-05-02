using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Exceptions;
using TestTask.Application.Interfaces;
using TestTask.Application.Products.Command.DeleteProduct;
using TestTask.Domain;

namespace TestTask.Application.Coins.Command.DeleteCoin
{
    public class DeleteCoinCommandHandler :
        IRequestHandler<DeleteCoinCommand, int>
    {
        public readonly ITestTaskDbContext _DbContext;
        public DeleteCoinCommandHandler(ITestTaskDbContext dbContext) =>
            _DbContext = dbContext;
        public async Task<int> Handle(DeleteCoinCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Coins
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Coin), request.Id);
            }
            _DbContext.Coins.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }
    }
}
