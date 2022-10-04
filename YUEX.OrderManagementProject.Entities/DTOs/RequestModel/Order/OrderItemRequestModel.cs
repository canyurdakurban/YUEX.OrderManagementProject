using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order
{
    public class OrderItemRequestModel : IDTO
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
