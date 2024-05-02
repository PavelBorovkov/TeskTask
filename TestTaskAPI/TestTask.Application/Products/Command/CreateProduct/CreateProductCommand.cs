using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
