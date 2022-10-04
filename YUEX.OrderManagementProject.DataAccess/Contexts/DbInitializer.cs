using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.DataAccess.Contexts
{
    public static class DbInitializer
    {
        public static void Initialize(OrderManagementContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;
            }

            var customer = new Customer[]
            {
                new Customer {UserName = "Can", UserAddress = "Güneşli", IsActive=true},
                new Customer {UserName = "Fatih", UserAddress = "Güneşli", IsActive=true},
            };

            foreach (Customer item in customer)
            {
                context.Customers.Add(item);
            }

            context.SaveChanges();

            var product = new Product[]
            {
                new Product{BarcodeNumber = "123456", Description="Laptop", Price = 10000, IsActive = true},
                new Product{BarcodeNumber = "654321", Description="Computer", Price = 8000, IsActive = true},
            };

            foreach (Product item in product)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();
            
            
        }
    }
}
