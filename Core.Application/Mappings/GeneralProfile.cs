using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Features.Products.Command;
using Core.Application.Features.Products.Query;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, UpdateProductCommandResponse>();
            CreateMap<Product, GetProductDetailsQueryResponse>();
            CreateMap<Product, ProductDto>();
        }
    }
}
