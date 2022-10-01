using System;
using System.Collections.Generic;
using System.Text;

namespace YUEX.OrderManagementProject.Entities.Entities
{
    public class Customer : BaseEntity
    {
        public string UserName { get; set; }

        public string UserAddress { get; set; }


        public ICollection<Order> Orders { get; set; }
        
    }
}
