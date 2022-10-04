using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using YUEX.OrderManagementProject.API;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;

namespace IntegrationTests.WebApi.Controllers.v1
{
    public class CustomerControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public CustomerControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]      
        public async Task CustomerTest()
        {
            string url = "/api/Customers/Create";
            string fileContent = File.ReadAllText(@"..\..\..\..\IntegrationTests\ExampleData\CustomerInsertRequest.json");
            
            var content = new StringContent(fileContent, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();
            var response = await client.PostAsync(url, content);

            Assert.True(response.IsSuccessStatusCode);            
        }

        
    }
}
