using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public Guid Id { get; set; }
    }
}
