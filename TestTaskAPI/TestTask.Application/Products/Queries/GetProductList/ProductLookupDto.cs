﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productDto => productDto.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.Quantity,
                opt => opt.MapFrom(product => product.Quantity));
        }
    }
}