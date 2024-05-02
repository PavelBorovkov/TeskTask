using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Exceptions;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler :
        IRequestHandler<DeleteProductCommand, Guid>
    {
        public readonly ITestTaskDbContext _DbContext;
        public DeleteProductCommandHandler(ITestTaskDbContext dbContext) =>
            _DbContext = dbContext;
        public async Task<Guid> Handle(DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Products
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            _DbContext.Products.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }
    }
}
