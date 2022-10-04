using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.IEntityRepository;

namespace YUEX.OrderManagementProject.Repository.Abstract
{
    public interface IOrderRepository : IEntityRepository<Order>, IEntityAsyncRepository<Order>
    {
    }
   
}
