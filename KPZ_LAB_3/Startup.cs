using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KPZ_LAB_3.Profiles;
using KPZ_LAB_3.Repository;
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

namespace KPZ_LAB_3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<JewelryStoreDbContext>();
            /*services.AddDbContext<JewelryStoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionJewelry"));
            });*/
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IJewelryStoreRepository, JewelryStoreRepository>();


            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyMethod().AllowAnyOrigin()
                        .AllowAnyHeader();
                    });
            });
            
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "KPZ_LAB_3", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KPZ_LAB_3 v1"));
            }

            

            //app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
