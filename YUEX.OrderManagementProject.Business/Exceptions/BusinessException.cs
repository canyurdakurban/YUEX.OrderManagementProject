﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YUEX.OrderManagementProject.Business.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
