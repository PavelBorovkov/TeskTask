using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Coins.Queries.GetCoinList
{
    public class CoinListVm
    {
        public IList<CoinLookupDto> Coins { get; set; }
    }
}
