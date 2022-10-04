using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.ResponseModel
{
    public class OrderResponseModel : IDTO
    {
        public CustomerInsertRequestModel Customer { get; set; }
        public List<OrderItemRequestModel> OrderItems { get; set; }
        public bool IsActive { get; set; }
    }
}
