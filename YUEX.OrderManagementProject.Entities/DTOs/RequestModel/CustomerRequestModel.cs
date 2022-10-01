using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel
{
    public class CustomerRequestModel : IDTO
    {
        public string UserName { get; set; }
        public string UserAddress { get; set; }
    }
}
