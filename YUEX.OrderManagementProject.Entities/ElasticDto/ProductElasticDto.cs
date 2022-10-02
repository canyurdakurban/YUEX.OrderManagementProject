using Nest;

namespace YUEX.OrderManagementProject.Entities.ElasticDto
{
    public class ProductElasticDto 
    {
        public string BarcodeNumber { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
