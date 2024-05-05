using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Exceptions;
using TestTask.Application.Interfaces;
using TestTask.Domain;

namespace TestTask.Application.Coins.Queries.GetCoin
{
    public class GetCoinQueryHandler : IRequestHandler<GetCoinQuery, CoinVm>
    {
        private readonly IMapper _mapper;
        private readonly ITestTaskDbContext _dbContext;
        public GetCoinQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CoinVm> Handle(GetCoinQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Coins
                .FirstOrDefaultAsync(coin =>
                coin.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Coin), request.Id);
            }
            return _mapper.Map<CoinVm>(entity);
        }
    }
}
