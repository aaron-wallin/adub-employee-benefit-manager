using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBM.Api.GraphRoot;
using EBM.Api.GraphTypes;
using EBM.BenefitLogic;
using EBM.BenefitLogic.BenefitPolicies;
using EBM.Data;
using EBM.Entities.Factories;
using EBM.PaycheckLogic;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EBM.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();
            }));


            // employee benefit objects for ioc
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IBenefitDiscountPolicy, NameDiscountPolicy>();
            services.AddSingleton<IBenefitCalculatorService, BenefitCalculatorService>();
            services.AddSingleton<IPaycheckCalculatorService, PaycheckCalculatorService>();
            services.AddSingleton<EmployeeFactory, EmployeeFactory>();
            services.AddSingleton<DependentFactory, DependentFactory>();

            // graph objects for ioc
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<GraphDataQuery>();
            services.AddSingleton<GraphDataMutation>();
            services.AddSingleton<EmployeeType>();
            services.AddSingleton<DependentType>();
            services.AddSingleton<EmployeeInputType>();
            services.AddSingleton<DependentInputType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphDataSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();
            });

            app.UseMvc();
        }
    }
}
