using Nest;
using YUEX.OrderManagementProject.Entities.ElasticDto;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.Repository.Abstract
{
    public interface IProductElasticRepository
    {
        void AddDocument(Product doc);
        bool DeleteDocument(int id);
        void UpdateDocument(Product entity);
        ISearchResponse<ProductElasticDto> Search(string text);
    }
}
