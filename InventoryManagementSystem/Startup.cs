using InventoryManagementSystem.Authentication;
using InventoryManagementSystem.Authentication.Interface;
using InventoryManagementSystem.BusinessLayer;
using InventoryManagementSystem.BusinessLayer.Interface;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagementSystem
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
            string key = "JeyakumarIMS";
            services.AddControllers();
            //services.AddDbContext<CustomerDbContext>(option => option.UseSqlServer(@"Data Source=DOTNETFSD01;Initial Catalog=CustomerDb;Integrated Security=True;"));
            services.AddDbContext<CustomerDbContext>(option => option.UseSqlServer(Configuration["ConnectionString:IMSDB"]));
            services.AddScoped<ICustomerDetails, CustomerDetailsBL>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ILog, Logger>();            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["ConnectionString:Redis"];
                options.InstanceName = "IMSInstance";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Customer API", Version = "v2" });
                c.ResolveConflictingActions(apiDescription => apiDescription.First());                
            });
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                }
                );
            services.AddSingleton<IAuthIMS>(new AuthenticationIMS(key));
        }
 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,CustomerDbContext customerDbcontext,ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };                    
                });
                
            });

            app.ConfigureExceptionHandler(logger);

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Customer API");                
            });

            app.UseHttpsRedirection();

            customerDbcontext.Database.EnsureCreated();

            app.UseRouting();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
