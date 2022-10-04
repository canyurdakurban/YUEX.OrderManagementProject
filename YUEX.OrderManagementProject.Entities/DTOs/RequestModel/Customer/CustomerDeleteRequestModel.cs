using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer
{
    public class CustomerDeleteRequestModel : IDTO
    {
        public int Id { get; set; }
    }
}
