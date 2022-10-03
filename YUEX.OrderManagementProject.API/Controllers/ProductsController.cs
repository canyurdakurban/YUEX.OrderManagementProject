using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Business.IService;
using YUEX.OrderManagementProject.Business.Service;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
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

        [HttpGet, Route("GetAll")]
        public IList<ProductResponseModel> GetAll()
        {
            return _productService.GetAllProduct();
        }

        [HttpGet, Route("GetbyId")]
        public ProductResponseModel Get([FromQuery] int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost, Route("Create")]
        public async Task Create([FromBody] ProductRequestModel request)
        {
            await _productService.CreateProduct(request);
        }

        [HttpPut, Route("Put")]
        public async Task Put([FromBody] ProductRequestModel request)
        {
            await _productService.UpdateProduct(request);
        }
    }
}
