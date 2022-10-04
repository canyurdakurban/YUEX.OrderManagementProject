using System;
using Xunit;
using wnCarrier.NetCore.Shared.Entities;
using wnCarrier.NetCore.Shared.Interfaces;
using wnCarrier.NetCore.CodeLib.Services;
using wnCarrier.NetCore.Shared.Enums;

namespace UnitTests
{
    public class ValidationTests
    {
        [Fact]
        public void MandatoryAllMissingFieldTest()
        {
            IValidateRequest validator = new DataValidationService(); 
            var request = new AllocateAndGetLabelRequest();
            var response = validator.ValidateRequest(request);

            bool expectedResult = false;

            Assert.Equal(expectedResult, response.IsValid);
        }

        [Fact(Skip = "JenkinsIgnore")]
        public void MandatoryCountryCodeMissingFieldTest()
        {
            IValidateRequest validator = new DataValidationService();
            var request = new AllocateAndGetLabelRequest();
            request.Parcel = new Parcel();
            request.Parcel.ScannedBarcode = "TEST123";
            request.Sender = new Sender();
            request.Consignee = new Consignee();
            request.Consignee.Address = new Address();
            request.Consignee.Address.CountryCode = String.Empty;
            request.Consignee.Address.ZipCode = "123";
            var response = validator.ValidateRequest(request);

            bool expectedResult = false;
            VALIDATION_ERROR_CODE expectedErrorCode = VALIDATION_ERROR_CODE.MANDATORY_FIELD_MISSING;
            string expectedErrorMessage = "Country code field cannot be empty";

            Assert.Equal(expectedResult, response.IsValid);
            Assert.Equal(expectedErrorCode, response.ValidationErrors[0].ValidationErrorCode);
            Assert.Equal(expectedErrorMessage, response.ValidationErrors[0].ValidationErrorMessage.ToString());
        }

        [Fact(Skip = "JenkinsIgnore")]
        public void MandatoryZipCodeMissingFieldTest()
        {
            IValidateRequest validator = new DataValidationService();
            var request = new AllocateAndGetLabelRequest();
            request.Parcel = new Parcel();
            request.Parcel.ScannedBarcode = "TEST123";
            request.Sender = new Sender();
            request.Consignee = new Consignee();
            request.Consignee.Address = new Address();
            request.Consignee.Address.CountryCode = "1234";
            request.Consignee.Address.ZipCode = String.Empty;
            var response = validator.ValidateRequest(request);

            bool expectedResult = false;
            VALIDATION_ERROR_CODE expectedErrorCode = VALIDATION_ERROR_CODE.MANDATORY_FIELD_MISSING;
            string expectedErrorMessage = "Zip code field cannot be empty";

            Assert.Equal(expectedResult, response.IsValid);
            Assert.Equal(expectedErrorCode, response.ValidationErrors[0].ValidationErrorCode);
            Assert.Equal(expectedErrorMessage, response.ValidationErrors[0].ValidationErrorMessage.ToString());
        }
    }
}
