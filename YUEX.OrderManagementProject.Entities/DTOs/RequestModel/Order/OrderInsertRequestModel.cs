using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order
{
    public class OrderInsertRequestModel : IDTO
    {        
        public int CustomerId { get; set; }
        public List<OrderItemRequestModel> OrderItems { get; set; }

    }
}
