using Lislokred_Web_API.Models.Entitys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Lislokred_Web_API
{

    public class Environment
    {
        public string ApplicationUrl { get; set; }
    }
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

            var config = new Environment();
            config.ApplicationUrl=Configuration["domen"];
            services.AddSingleton(config);

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var authOptionalConfigure = Configuration.GetSection("Auth");
            services.Configure<AuthOption>(authOptionalConfigure);

            var authOptional = Configuration.GetSection("Auth").Get<AuthOption>();
                
            services.AddControllers().AddJsonOptions(options =>
            {
                //options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                //������� ��� ������������ ��������������� � camelCase
                //��������� �������� � ���������
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });


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

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    //.RequireClaim(User.Claims.FirstOrDefault(c => c.Type == "Id").Value)
                    .Build();
            });

            services.AddCors();
            
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

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
             Path.Combine(env.ContentRootPath, "Pictures")),
                RequestPath = "/Pictures"
            });
            //������� ������� � ������ ����� � ���������� �����
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            // Path.Combine(env.ContentRootPath, "Pictures/Movies")),
            //    RequestPath = "/Movies"
            //});
            app.UseAuthentication();
            app.UseAuthorization();

            //������� 2
            //  app.UseStaticFiles(new StaticFileOptions
            //  {
            //      FileProvider = new PhysicalFileProvider(
            //Path.Combine(env.ContentRootPath, "Pictures/Users")),
            //      RequestPath = "/Users"
            //  });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
