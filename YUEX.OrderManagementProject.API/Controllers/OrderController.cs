using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Business.IService;
using YUEX.OrderManagementProject.Business.Service;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;

namespace YUEX.OrderManagementProject.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Route("GetAll")]
        public async Task<IList<OrderResponseModel>> GetAll()
        {
            return await _orderService.GetAll();
        }

        [HttpGet, Route("GetbyId")]
        public async Task<OrderResponseModel> Get([FromQuery] int id)
        {
            return await _orderService.GetById(id);
        }

        [HttpPost, Route("Create")]
        public async Task Create([FromBody] OrderInsertRequestModel request)
        {
            await _orderService.Add(request);
        }

        [HttpPut, Route("Put")]
        public async Task Put([FromBody] OrderUpdateRequestModel request)
        {
            await _orderService.Update(request);
        }

        [HttpDelete, Route("Delete")]
        public async Task Delete([FromBody] OrderDeleteModel request)
        {
            await _orderService.Delete(request);
        }

    }
}
