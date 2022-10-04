using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;

namespace YUEX.OrderManagementProject.Business.Validator
{
    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateRequestModel>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x=> x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.UserName).Length(3, 100);
            RuleFor(x => x.UserAddress).NotEmpty().NotNull();
            RuleFor(x => x.UserAddress).Length(10, 200);
        }
    }
}
