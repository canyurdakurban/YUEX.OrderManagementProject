using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Business.IService;

namespace YUEX.OrderManagementProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet, Route("GetAll")]
        public async Task<IList<CustomerResponseModel>> GetAll()
        {
            return await _customerService.GetAll();
        }

        [HttpGet, Route("GetbyId")]
        public async Task<CustomerResponseModel> Get([FromQuery] int id)
        {
            return await _customerService.GetById(id);
        }

        [HttpPost, Route("Create")]
        public async Task Create([FromBody] CustomerRequestModel request)
        {
            await _customerService.Add(request);
        }

        [HttpPut, Route("Put")]
        public async Task Put([FromBody] CustomerRequestModel request)
        {
            await _customerService.Update(request);
        }

        [HttpPut, Route("Delete")]
        public async Task Delete([FromBody] CustomerDeleteModel request)
        {
            await _customerService.Delete(request);
        }
    }
}
