using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Common.Exceptions;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IMapper _mapper;
        private readonly ITestTaskDbContext _dbContext;
        public GetProductQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductVm> Handle(GetProductQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .FirstOrDefaultAsync(product =>
                product.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            return _mapper.Map<ProductVm>(entity);
        }
    }
}
