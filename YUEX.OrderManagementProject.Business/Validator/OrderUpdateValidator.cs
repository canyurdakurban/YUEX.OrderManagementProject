using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;

namespace YUEX.OrderManagementProject.Business.Validator
{
    public class OrderUpdateValidator : AbstractValidator<OrderUpdateRequestModel>
    {
        public OrderUpdateValidator()
        {
            
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleFor(x => x.OrderItems).NotNull();
        }
        
        
    }
}
