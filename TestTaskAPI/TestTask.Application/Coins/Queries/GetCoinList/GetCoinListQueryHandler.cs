using AutoMapper;
using MediatR;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Interfaces;

namespace TestTask.Application.Coins.Queries.GetCoinList
{
    public class GetCoinListQueryHandler : IRequestHandler<GetCoinListQuery, CoinListVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCoinListQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CoinListVm> Handle(GetCoinListQuery request,
            CancellationToken cancellationToken)
        {
            var coinQuery = _dbContext.Coins.ProjectTo<CoinLookupDto>(_mapper.ConfigurationProvider);
            if (request.Value!=null)
            {
                coinQuery = coinQuery.Where(p => p.Value==request.Value);
            }
            return new CoinListVm { Coins = coinQuery.ToList() };
        }
    }
}
