using Nest;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.ElasticDto;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.Repository.Abstract
{
    public interface IProductElasticRepository
    {
        Task AddDocument(Product doc);
        bool DeleteDocument(int id);
        void UpdateDocument(Product entity);
        ISearchResponse<ProductElasticDto> Search(string text);
    }
}
