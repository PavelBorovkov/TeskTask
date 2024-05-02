using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Products.Command.CreateProduct;

namespace TestTask.Application.Coins.Command.CreateCoin
{
    public class CreateCoinCommandValidator : AbstractValidator<CreateCoinCommand>
    {
        public CreateCoinCommandValidator()
        {
            RuleFor(createCoinCommand =>
            createCoinCommand.Value).GreaterThanOrEqualTo(0);
            RuleFor(createCoinCommand => 
            createCoinCommand.Quantity).GreaterThanOrEqualTo(-1);
        }
    }
}
