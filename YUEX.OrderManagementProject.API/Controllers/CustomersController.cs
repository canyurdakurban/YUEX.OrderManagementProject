using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Business.IService;

namespace YUEX.OrderManagenetProject.API.Controllers
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

        [HttpGet]
        public async Task<IList<CustomerResponseModel>> GetAll()
        {
            return await _customerService.GetAll();
        }

        [HttpGet]
        public async Task<CustomerResponseModel> Get([FromQuery] int id)
        {
            return await _customerService.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] CustomerRequestModel request)
        {
            await _customerService.Add(request);
        }

        [HttpPut]
        public async Task Put([FromBody] CustomerRequestModel request)
        {
            await _customerService.Update(request);
        }
    }
}
