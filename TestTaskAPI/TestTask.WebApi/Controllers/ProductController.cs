using Microsoft.AspNetCore.Mvc;
using TestTask.Domain;
using AutoMapper;
using TestTask.Application.Products.Command.CreateProduct;
using TestTask.Application.Products.Command.DeleteProduct;
using TestTask.Application.Products.Command.UpdateProduct;
using TestTask.Application.Products.Queries.GetProductList;

namespace TestTask.WebApi.Controllers
{
    [Route("products/[controller]/[action]")]
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLookupDto>>> GetAllProduct(string? name)
        {
            var query = new GetProductListQuery
            {
                Name = name
            };
            var vm = await Mediator.Send(query);
            List<ProductLookupDto> products = new List<ProductLookupDto>();
            foreach (var product in vm.Products)
            {
                products.Add(product);
            }
            return Ok(products);
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] CreateProductCommand createProductCommand)
        {
            if (string.IsNullOrEmpty(createProductCommand.Name))
            {
                return BadRequest(createProductCommand.Name);
            }
            else if (createProductCommand.Quantity.Equals(null)&& createProductCommand.Quantity<0)
            {
                return BadRequest(createProductCommand.Quantity);
            }
            else if (createProductCommand.Price.Equals(null)&& createProductCommand.Price<0)
            {
                return BadRequest(createProductCommand.Price);
            }
            else
            {
                var product = await Mediator.Send(createProductCommand);
                return Ok(product);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            if (string.IsNullOrEmpty(updateProductCommand.Name))
            {
                return BadRequest(updateProductCommand.Name);
            }
            else if (updateProductCommand.Quantity.Equals(null))
            {
                return BadRequest(updateProductCommand.Quantity);
            }
            else if (updateProductCommand.Price.Equals(null))
            {
                return BadRequest(updateProductCommand.Price);
            }
            else
            {
                var product = await Mediator.Send(updateProductCommand);
                return Ok(product);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

    }
}
