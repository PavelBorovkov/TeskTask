using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Coins.Command.DeleteCoin
{
    public class DeleteCoinCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
