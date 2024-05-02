using MediatR;
using Microsoft.EntityFrameworkCore;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Exceptions;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.Coins.Command.UpdateCoin
{
    public class UpdateCoinCommandHandler :
        IRequestHandler<UpdateCoinCommand, Coin>
    {
        private readonly ITestTaskDbContext _dbContext;
        public UpdateCoinCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Coin> Handle(UpdateCoinCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Coins.FirstOrDefaultAsync(
                Coin => Coin.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Coin), request.Id);
            }
            entity.Value = request.Value;
            entity.Quantity = request.Quantity;
            entity.Access = request.Access;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
