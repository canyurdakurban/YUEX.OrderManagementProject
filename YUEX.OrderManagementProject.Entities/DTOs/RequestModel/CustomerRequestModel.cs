﻿using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.DTOs.RequestModel
{
    public class CustomerRequestModel : IDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
    }
}
