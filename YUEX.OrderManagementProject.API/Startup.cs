using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.Repository.ElasticSearch;
using YUEX.OrderManagementProject.Repository.EntityFramework;
using YUEX.OrderManagementProject.Business.IService;
using YUEX.OrderManagementProject.Business.Mapper;
using YUEX.OrderManagementProject.Business.Rules;
using YUEX.OrderManagementProject.Business.Service;
using YUEX.OrderManagementProject.DataAccess.Contexts;
using YUEX.OrderManagementProject.Business.Exceptions;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;
using YUEX.OrderManagementProject.Business.Validator;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Order;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product;

namespace YUEX.OrderManagementProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OrderManagementContext>(options =>
                                   options.UseSqlServer(Configuration.GetSection("AppConfig:ConnectionStrings").Value), ServiceLifetime.Transient);

            services.AddAutoMapper(typeof(MapperService));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<CustomerBusinessRules>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductElasticRepository, ProductElasticRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();


            //Fluent validator
            services.AddScoped<IValidator<CustomerInsertRequestModel>, CustomerInsertValidator>();
            services.AddScoped<IValidator<CustomerUpdateRequestModel>, CustomerUpdateValidator>();
            services.AddScoped<IValidator<OrderInsertRequestModel>, OrderInsertValidator>();
            services.AddScoped<IValidator<OrderUpdateRequestModel>, OrderUpdateValidator>();
            services.AddScoped<IValidator<ProductInsertRequestModel>, ProductInsertValidator>();
            services.AddScoped<IValidator<ProductUpdateRequestModel>, ProductUpdateValidator>();


            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;

                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

                // Other way to register validators
                //fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            }); ;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YUEX.OrderManagement.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YUEX.OrderManagement.API v1"));

            app.UseHttpsRedirection();

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
