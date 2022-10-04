using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Business.IService;
using YUEX.OrderManagementProject.Business.Service;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;

namespace YUEX.OrderManagementProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("search")]
        public  IList<ProductResponseModel> Search([FromQuery] string searchText)
        {
            return  _productService.SearchProduct(searchText);
        }

        [HttpGet, Route("GetAll")]
        public async Task<IList<ProductResponseModel>> GetAll()
        {
            return await _productService.GetAllProduct();
        }

        [HttpGet, Route("GetbyId")]
        public async Task<ProductResponseModel> Get([FromQuery] int id)
        {
            return await _productService.GetProductById(id);
        }

        [HttpPost, Route("Create")]
        public async Task Create([FromBody] ProductInsertRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Model state is not valid");
            }
            await _productService.CreateProduct(request);
        }

        [HttpPut, Route("Put")]
        public async Task Put([FromBody] ProductUpdateRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Model state is not valid");
            }
            await _productService.UpdateProduct(request);
        }

        [HttpDelete, Route("Delete")]
        public async Task Delete([FromBody] ProductDeleteRequestModel request)
        {
            await _productService.DeleteProduct(request);
        }
    }
}
