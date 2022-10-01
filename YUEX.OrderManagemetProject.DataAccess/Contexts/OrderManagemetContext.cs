using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagemetProject.DataAccess.Contexts
{
    public class OrderManagemetContext : DbContext
    {
        public OrderManagemetContext(DbContextOptions<OrderManagemetContext> options) : base(options) 
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
       

    }
}
