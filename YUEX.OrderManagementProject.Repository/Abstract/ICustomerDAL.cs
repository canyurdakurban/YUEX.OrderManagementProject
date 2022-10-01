using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.IEntityRepository;

namespace YUEX.OrderManagementProject.Repository.Abstract
{
    public interface ICustomerDAL : IEntityRepository<Customer>, IEntityAsyncRepository<Customer>
    {
    }
   
}
