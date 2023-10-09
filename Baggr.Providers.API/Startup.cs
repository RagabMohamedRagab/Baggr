using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.BLL.Manager;
using Baggr.Providers.Common;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.FedexModels;
using Baggr.Providers.DTO.FetchrModels;
using Baggr.Providers.DTO.J_TExpressModels;
using Baggr.Providers.DTO.MylerzModels;
using Baggr.Providers.Entities;
using Baggr.Providers.Factory.Factory;
using Baggr.Providers.Factory.IFactory;
using Baggr.Providers.Gateway.APIs;
using Baggr.Providers.Gateway.IAPIs;
using Baggr.Providers.IMP.Company;
using Baggr.Providers.IMP.ICompany;
using Baggr.Providers.IMP.IProvider;
using Baggr.Providers.IMP.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baggr.Providers.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AramexConfig>(Configuration.GetSection("GateWay:Aramex"));
            services.Configure<FedexConfig>(Configuration.GetSection("GateWay:Fedex"));
            services.Configure<MylerzConfig>(Configuration.GetSection("GateWay:Mylerz"));
            services.Configure<JTExpressConfig>(Configuration.GetSection("GateWay:JTExpress"));
            //Database Connection
            services.AddDbContext<ProvidersContext>(options =>
              options.UseMySql(Configuration.GetConnectionString("UsersDatabaseConnection")));

            //Seeder(Migration)
            services.AddTransient<Seeder>();

            services.AddCors(o => o.AddDefaultPolicy( builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }
            ));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Providers API",

                });
            });
            //Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProvidersMappingProfile(Configuration));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IProvidersContext, ProvidersContext>();
            services.AddScoped(typeof(IProvidersRepository<>), typeof(ProvidersRepository<>));

            //////////Manager////////////////////
            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<IProviderManager, ProviderManager>();
            services.AddScoped<IShipmentManager, ShipmentManager>();
            services.AddScoped<IAnalyticsManager, AnalyticsManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped< IJTExpressCityZonesManager, JTExpressCityZonesManager>();
            /////////Factory/////////////////////
            services.AddScoped<ICityFactory, CityFactory>();
            services.AddScoped<IShipmentFactory, ShipmentFactory>();
            services.AddScoped<IAnalyticsFactory, AnalyticsFactory>();
            services.AddScoped<IProviderFactory, ProviderFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IOrderFactory, OrderFactory>();
            services.AddScoped<IJtExpressCityZoneFactory, JTExpressCityZoneFactory>();
            ////////GateWay///////////////////////
            services.AddScoped<IAramexAPI, AramexAPI>();
            services.AddScoped<IFedexAPI, FedexAPI>();
            services.AddScoped<IMylerzAPI, MylerzAPI>();
            services.AddScoped<IJTExpressAPI, JTExpressAPI>();
            ///////////////////IMP/////////////////
            services.AddScoped<IAramexManager, AramexManager>();
            services.AddScoped<IFedexManager, FedexManager>();
            services.AddScoped<IFetchrManager, FetchrManager>();
            services.AddScoped<IMylerzManager, MylerzManager>();
            services.AddScoped<IJTExpressManager, JTExpressManager>();

            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerUI(c =>
            {
                c.ConfigObject = new ConfigObject
                {
                    ShowCommonExtensions = true
                };
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Users API V1");
                c.RoutePrefix = string.Empty;

            });
            app.UseDeveloperExceptionPage();

            // Enable middleware to serve generated Swagger as a JSON endpoint.

            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseRouting();
             app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var provider = app.ApplicationServices;
            var scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<Seeder>();
                seeder.Seed();
            }
        }
    }
}
