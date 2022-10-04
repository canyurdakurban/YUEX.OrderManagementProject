using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;

namespace YUEX.OrderManagementProject.Business.IService
{
    public interface IOrderService
    {
        Task<OrderResponseModel> GetById(int id);
        Task<OrderResponseModel> Add(OrderInsertRequestModel reuest);
        Task Delete(OrderDeleteModel reuest);
        Task<OrderResponseModel> Update(OrderUpdateRequestModel request);
        Task<IList<OrderResponseModel>> GetAll();
    }
}
