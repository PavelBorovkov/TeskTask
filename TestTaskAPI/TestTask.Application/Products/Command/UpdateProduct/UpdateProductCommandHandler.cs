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

namespace TestTask.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler :
        IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly ITestTaskDbContext _dbContext;
        public UpdateProductCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Product> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(
                Product => Product.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            entity.Price = request.Price;
            entity.Quantity = request.Quantity;
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
