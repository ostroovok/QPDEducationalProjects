using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NinthThemeSolution.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NinthThemeSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //var tokenHandler = new JwtSecurityTokenHandler();

            //var tokenDescriptor = new SecurityTokenDescriptor();

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("123456789")),

                            ValidateIssuerSigningKey = true,
                        };
                    });
            */

            //https://alekseev74.ru/lessons/show/aspnet-mvc/session   --- смотреть здесь

            services.AddSession();

            services.AddControllersWithViews();

            services.AddDbContext<BotRepositoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BotResponseConnection")));


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
