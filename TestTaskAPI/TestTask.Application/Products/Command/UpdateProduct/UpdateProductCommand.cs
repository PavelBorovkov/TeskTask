using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Products.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ImgLink { get; set; }
    }
}
