using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Coins.Queries.GetCoinList
{
    public class CoinLookupDto : IMapWith<Coin>
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public bool Access { get; set; }
        public int Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Coin, CoinLookupDto>()
                .ForMember(coinDto => coinDto.Id,
                opt => opt.MapFrom(coin => coin.Id))
                .ForMember(coinDto => coinDto.Value,
                opt => opt.MapFrom(coin => coin.Value))
                .ForMember(coinDto => coinDto.Quantity,
                opt => opt.MapFrom(coin => coin.Quantity))
                .ForMember(coinDto => coinDto.Access,
                opt => opt.MapFrom(coin => coin.Access));
        }
    }
}
