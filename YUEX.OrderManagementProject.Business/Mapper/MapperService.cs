using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.ElasticDto;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.Business.Mapper
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<CustomerRequestModel, Customer>().ReverseMap();
            CreateMap<CustomerResponseModel, Customer>().ReverseMap();
            CreateMap<ProductRequestModel, Product>().ReverseMap();
            CreateMap<ProductResponseModel, Product>().ReverseMap();
            CreateMap<ProductElasticDto, Product>().ReverseMap();
            CreateMap<ProductResponseModel, ProductElasticDto>().ReverseMap();

        }


    }
}
