using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Products.Queries.GetProductList;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProduct
{
    public class ProductVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImgLink { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>()
                .ForMember(productDto => productDto.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productDto => productDto.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.Quantity,
                opt => opt.MapFrom(product => product.Quantity))
                .ForMember(productDto => productDto.ImgLink,
                opt => opt.MapFrom(product => product.ImgLink));
        }

    }
}
