using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product;

namespace YUEX.OrderManagementProject.Business.Validator
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateRequestModel>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.BarcodeNumber).NotEmpty().NotNull();
            RuleFor(x => x.BarcodeNumber).Length(5, 12);
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Description).Length(10, 200);
        }
    }
}
