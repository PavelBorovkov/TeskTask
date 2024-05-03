using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Coins.Command.UpdateCoin
{
    public class UpdateCoinCommandValidator : AbstractValidator<UpdateCoinCommand>
    {
        public UpdateCoinCommandValidator()
        {
            RuleFor(updateCoinCommand =>
            updateCoinCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(updateCoinCommand =>
            updateCoinCommand.Value).GreaterThanOrEqualTo(0);
            RuleFor(updateCoinCommand =>
            updateCoinCommand.Quantity).GreaterThanOrEqualTo(-1);
        }
    }
}
