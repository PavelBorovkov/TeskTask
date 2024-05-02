using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Coins.Command.UpdateCoin
{
    public class UpdateCoinCommand:IRequest<Coin>
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public bool Access { get; set; }
        public int Quantity { get; set; }
    }
}
