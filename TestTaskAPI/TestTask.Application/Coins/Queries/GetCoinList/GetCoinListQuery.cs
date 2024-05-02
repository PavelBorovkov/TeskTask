using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Coins.Queries.GetCoinList
{
    public class GetCoinListQuery : IRequest<CoinListVm>
    {
        public int? Value { get; set; }
    }
}
