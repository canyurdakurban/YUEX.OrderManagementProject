using Microsoft.AspNetCore.Hosting;

namespace IntegrationTests
{
    public class WebApplicationFactory<TEntryPoint> : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TEntryPoint>
       where TEntryPoint : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
        }
    }
}
