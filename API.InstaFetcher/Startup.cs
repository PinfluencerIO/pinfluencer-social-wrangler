using System.Threading.Tasks;
using API.InstaFetcher.Middleware;
using Auth0.ManagementApi;
using Bootstrapping.Services.Repositories;
using DAL.Instagram;
using DAL.Instagram.Repositories;
using DAL.UserManagement;
using DAL.UserManagement.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace API.InstaFetcher
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Auth0Context>();
            services.AddScoped<FacebookContext>();

            services.AddTransient<IUserRepository,Auth0UserRepository>();
            services.AddTransient<IInstaImpressionsRepository,FacebookInstaImpressionsRepository>();
            services.AddTransient<IInstaUserRepository,FacebookInstaUserRepository>();

            services.AddTransient<IManagementConnection, HttpClientManagementConnection>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<FacebookMiddlware>();
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}