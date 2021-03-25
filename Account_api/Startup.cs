using Account_api.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_api
{
    /// <summary>
    /// 起始設定
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Account_api", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DbConnection"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
              {
                  // 當驗證失敗時，顯示失敗的詳細錯誤原因
                  options.IncludeErrorDetails = true; 
                options.TokenValidationParameters = new TokenValidationParameters
                  {
                    //  "sub" 取值並設定給 User.Identity.Name
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                    // 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    // 驗證Issuer
                    ValidateIssuer = true,
                      ValidIssuer = Configuration["Jwt:Issuer"], 
                    // 不需要驗證 Audience
                    ValidateAudience = false,
                    // 驗證 Token 的有效期間
                    ValidateLifetime = true,
                    // 不用KEY
                    ValidateIssuerSigningKey = false,

                    // "1234567890123456" 應該從 IConfiguration 取得
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });
            // CORS
            services.AddCors(options =>
            {
                // 先不鎖CORS
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.SetIsOriginAllowed(origin => true)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account_api v1"));
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            dataContext.Database.EnsureCreated();

            //CORS
            app.UseCors("CorsPolicy");
        }
    }
}
