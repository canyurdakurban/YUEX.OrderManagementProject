using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.ResponseModel
{
    public class ProductResponceModel : IDTO
    {
        public string BarcodeNumber { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
