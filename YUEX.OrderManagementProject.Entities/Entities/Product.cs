using System;
using System.Collections.Generic;
using System.Text;

namespace YUEX.OrderManagementProject.Entities.Entities
{
    public class Product : BaseEntity
    {
        public string BarcodeNumber { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
