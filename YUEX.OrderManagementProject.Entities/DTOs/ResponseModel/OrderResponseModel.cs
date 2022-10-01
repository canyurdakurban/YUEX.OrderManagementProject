using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.ResponseModel
{
    public class OrderResponseModel : IDTO
    {
        public CustomerRequestModel Customer { get; set; }
        public List<OrderItemRequestModel> OrderItems { get; set; }
    }
}
