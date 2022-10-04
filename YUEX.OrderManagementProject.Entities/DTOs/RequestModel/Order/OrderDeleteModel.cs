using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order
{
    public class OrderDeleteModel : IDTO
    {
        public int Id { get; set; }
    }
}
