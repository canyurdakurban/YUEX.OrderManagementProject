using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product
{
    public class ProductInsertRequestModel : IDTO
    {        
        public string BarcodeNumber { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
