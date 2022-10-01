using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.ResponseModel
{
    public class CustomerResponseModel : IDTO
    {
        public string UserName { get; set; }

        public string UserAddress { get; set; }
    }
}
