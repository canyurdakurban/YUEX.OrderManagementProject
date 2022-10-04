using AutoMapper;
using Nest;
using System;
using System.Collections.Generic;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.Business.IService;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using YUEX.OrderManagementProject.Business.Exceptions;

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

        public async Task<ProductResponseModel> CreateProduct(ProductInsertRequestModel productRequest)
        {
            Product product = _mapper.Map<Product>(productRequest);
            product.IsActive = true;
            product = await _productRepository.AddAsync(product);
            
            if (product != null)
            {
               await _productElasticRepository.AddDocument(_mapper.Map<Product>(product));
                
            }            

            return _mapper.Map<ProductResponseModel>(product);
        }

        public async Task DeleteProduct(ProductDeleteRequestModel request)
        {
            var result = await GetByIdInternal(request.Id);

            _productRepository.Delete(result);
            _productElasticRepository.DeleteDocument(request.Id);
        }

        public async Task<IList<ProductResponseModel>> GetAllProduct()
        {
            return _mapper.Map<IList<ProductResponseModel>>(await _productRepository.GetListAsync());
        }

        public async Task<ProductResponseModel> GetProductById(int id)
        {
            return _mapper.Map<ProductResponseModel>(await _productRepository.GetAsync(x => x.Id == id));
        }

        public IList<ProductResponseModel> SearchProduct(string searchText)
        {
            var result = _productElasticRepository.Search(searchText);
            return _mapper.Map<IList<ProductResponseModel>>(result.Documents);
        }

        public async Task<ProductResponseModel> UpdateProduct(ProductUpdateRequestModel productRequest)
        {
            var result = await GetByIdInternal(productRequest.Id);

            result.BarcodeNumber = productRequest.BarcodeNumber;
            result.Description = productRequest.Description;
            result.Price = productRequest.Price;

            Product orderEntity = await _productRepository.UpdateAsync(result);
            ProductResponseModel orderResponce = _mapper.Map<ProductResponseModel>(orderEntity);

            return orderResponce;
        }

        public async Task<Product> GetByIdInternal(int id)
        {
            return await _productRepository.GetAsync(x => x.Id == id);
        }
    }
}
