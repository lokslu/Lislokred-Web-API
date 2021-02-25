using Lislokred_Web_API.Models.Entitys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lislokred_Web_API
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

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var authOptionalConfigure = Configuration.GetSection("Auth");
            services.Configure<AuthOption>(authOptionalConfigure);

            var authOptional = Configuration.GetSection("Auth").Get<AuthOption>();
                
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = true;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           // ��������, ����� �� �������������� �������� ��� ��������� ������
                           ValidateIssuer = true,
                           // ������, �������������� ��������
                           ValidIssuer = authOptional.Issuer,

                           // ����� �� �������������� ����������� ������
                           ValidateAudience = true,
                           // ��������� ����������� ������
                           ValidAudience = authOptional.Audience,
                           // ����� �� �������������� ����� �������������
                           ValidateLifetime = true,

                           // ��������� ����� ������������
                           IssuerSigningKey = authOptional.GetSymmetricSecurityKey(),
                           // ��������� ����� ������������
                           ValidateIssuerSigningKey = true,
                       };
                   });
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lislokred_Web_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lislokred_Web_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
             Path.Combine(env.ContentRootPath, "Pictures")),
                RequestPath = "/Pictures"
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
