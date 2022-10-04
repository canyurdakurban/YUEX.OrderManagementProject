using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.ElasticDto;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.Business.Mapper
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<CustomerInsertRequestModel, Customer>().ReverseMap();
            CreateMap<CustomerUpdateRequestModel, Customer>().ReverseMap();            
            CreateMap<CustomerResponseModel, Customer>().ReverseMap();

            CreateMap<ProductInsertRequestModel, Product>().ReverseMap();
            CreateMap<ProductUpdateRequestModel, Product>().ReverseMap();
            CreateMap<ProductResponseModel, Product>().ReverseMap();
            CreateMap<ProductElasticDto, Product>().ReverseMap();
            CreateMap<ProductResponseModel, ProductElasticDto>().ReverseMap();

            CreateMap<OrderInsertRequestModel, Order>().ReverseMap();
            CreateMap<OrderUpdateRequestModel, Order>().ReverseMap();


        }


    }
}
