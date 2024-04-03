using AutoMapper;
using CleanArchitecture.Contract.Services.Product;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    public class ServiceProfile : Profile
    { 
        public ServiceProfile()
        {
            CreateMap<Product, Response.ProductResponse>().ReverseMap();
        }
    }
}
