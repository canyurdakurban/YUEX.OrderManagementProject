using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.IEntityRepository;

namespace YUEX.OrderManagementProject.Repository.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>, IEntityAsyncRepository<Product>
    {
    }
}
