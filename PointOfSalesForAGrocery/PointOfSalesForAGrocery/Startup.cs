using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using POS.DataSource;
using AutoMapper;
using PointOfSalesForAGrocery.Repository;
using POS.Models;
using PointOfSalesForAGrocery.Repository.Implementation;
using Microsoft.AspNetCore.Identity;

namespace PointOfSalesForAGrocery
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string constring = Configuration["ConnectionString:Constring"];
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer("Data Source=.\\MSSQL;Initial Catalog=POSSYSTEM;Integrated Security=True"));

            services.AddControllers().AddNewtonsoftJson();
            services.AddDefaultIdentity<IdentityUser>()
                //.AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IInventoryRepository, InventoryRepo>();
            services.AddScoped<IItemCatogaryRepository, ItemCatogaryRepo>();
            services.AddScoped<IItemLocationRepository, ItemlocationRepo>();
            services.AddScoped<IUnitMesurementRepositorys, UnitMesurementRepo>();
            services.AddScoped<IExpensesRepository, ExpensesRepo>();
            services.AddScoped<IBillRepository, BillRepo>();

            services.AddAutoMapper(typeof(AuttoMapping));
            services.AddMvc().AddNewtonsoftJson();
            

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            

            //services.AddEntityFrameworkSqlServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            

            app.UseRouting();

            app.UseCors("MyAllowSpecificOrigins");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
