using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Coins.Queries.GetCoin
{
    public class CoinVm : IMapWith<Coin>
    {
        public int Value { get; set; }
        public int Quantity { get; set; }
        public bool Access { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Coin, CoinVm>()
                .ForMember(CoinVm => CoinVm.Value,
                    opt => opt.MapFrom(CoinVm => CoinVm.Value))
                .ForMember(CoinVm => CoinVm.Quantity,
                    opt => opt.MapFrom(CoinVm => CoinVm.Quantity))
                .ForMember(CoinVm => CoinVm.Access,
                    opt => opt.MapFrom(CoinVm => CoinVm.Access));

        }

    }
}
