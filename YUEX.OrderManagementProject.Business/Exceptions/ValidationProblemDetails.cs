using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YUEX.OrderManagementProject.Business.Exceptions
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public object Errors { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
