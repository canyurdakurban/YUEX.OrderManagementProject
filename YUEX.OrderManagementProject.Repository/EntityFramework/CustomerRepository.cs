using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.DataAccess.Contexts;

namespace YUEX.OrderManagementProject.Repository.EntityFramework
{
    public class CustomerRepository : EfRepositoryBase<Customer, OrderManagementContext>, ICustomerRepository
    {
        public CustomerRepository(OrderManagementContext context) : base(context)
        {
        }
    }
}
