using Nest;
using System;

namespace YUEX.OrderManagementProject.Entities.ElasticDto
{
    [Serializable]
    public class ProductElasticDto 
    {
        public string BarcodeNumber { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
