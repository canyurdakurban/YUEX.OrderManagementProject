using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.DataAccess.Contexts;

namespace YUEX.OrderManagementProject.Repository.EntityFramework
{
    public class OrderRepository : EfRepositoryBase<Order, OrderManagementContext>, IOrderRepository
    {
        public OrderRepository(OrderManagementContext context) : base(context)
        {
        }
    }
}
