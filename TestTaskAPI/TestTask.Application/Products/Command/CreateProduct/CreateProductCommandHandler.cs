using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :
        IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ITestTaskDbContext _DbContext;
        public CreateProductCommandHandler(ITestTaskDbContext dbContext) =>
            _DbContext = dbContext;
        public async Task<Guid> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Quantity = request.Quantity,
                Price = request.Price,
                ImgLink= request.ImgLink
            };
            await _DbContext.Products.AddAsync(product, cancellationToken);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
