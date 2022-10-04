using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order
{
    public class OrderUpdateRequestModel : IDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemRequestModel> OrderItems { get; set; }

    }
}
