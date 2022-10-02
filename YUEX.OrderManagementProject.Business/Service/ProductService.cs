using AutoMapper;
using Nest;
using System;
using System.Collections.Generic;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.Business.IService;

namespace YUEX.OrderManagementProject.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductElasticRepository _productElasticRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, 
                              IProductElasticRepository productElasticRepository,
                              IMapper mapper)
        {
            _productRepository = productRepository;
            _productElasticRepository = productElasticRepository;
            _mapper = mapper;
        }

        public void CreateProduct(ProductRequestModel productRequest)
        {
            _productRepository.Add(_mapper.Map<Product>(productRequest));

            _productElasticRepository.AddDocument(_mapper.Map<Product>(productRequest));
        }

        public async void DeleteProduct(int id)
        {
            var result = await _productRepository.GetAsync(x => x.Id == id);

            _productRepository.Delete(result);
            _productElasticRepository.DeleteDocument(id);
        }

        public IList<ProductResponseModel> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public ProductResponseModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductResponseModel> SearchProduct(string searchText)
        {
            var result = _productElasticRepository.Search(searchText);
            return _mapper.Map<IList<ProductResponseModel>>(result.Documents);
        }

        public void UpdateProduct(ProductRequestModel productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
