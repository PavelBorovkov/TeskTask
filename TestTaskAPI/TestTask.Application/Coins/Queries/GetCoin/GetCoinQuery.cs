using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Application.Coins.Queries.GetCoin
{
    public class GetCoinQuery : IRequest<CoinVm>
    {
        public int Id { get; set; }
    }
}
