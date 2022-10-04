using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product
{
    public class ProductDeleteRequestModel : IDTO
    {
        public int Id { get; set; }
    }
}
