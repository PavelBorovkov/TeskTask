using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Coins.Command.CreateCoin
{
    public class CreateCoinCommand : IRequest<int>
    {
        public int Value { get; set; }
        public int Quantity { get; set; }
        public bool Access { get; set; }
    }
}
