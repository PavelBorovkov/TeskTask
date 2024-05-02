using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Name).NotEqual(string.Empty);
            RuleFor(createProductCommand =>
            createProductCommand.Price)
                .GreaterThanOrEqualTo(decimal.Zero)
                .NotEqual(decimal.Zero);
            RuleFor(createProductCommand =>
            createProductCommand.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}
