using System.Threading.Tasks;
using API.InstaFetcher.Middleware;
using Auth0.ManagementApi;
using Bootstrapping.Services.Factories;
using Bootstrapping.Services.Repositories;
using DAL.Instagram;
using DAL.Instagram.Factories;
using DAL.Instagram.Repositories;
using DAL.UserManagement;
using DAL.UserManagement.Factories;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Auth0Context>();
            services.AddScoped<FacebookContext>();

            services.AddTransient<IFacebookClientFactory,FacebookClientFactory>();
            services.AddTransient<IAuth0AuthenticationApiClientFactory, Auth0AuthenticationApiClientFactory>();

            services.AddTransient<IUserRepository,Auth0UserRepository>();
            services.AddTransient<IInstaImpressionsRepository,FacebookInstaImpressionsRepository>();
            services.AddTransient<IInstaUserRepository,FacebookInstaUserRepository>();

            services.AddTransient<IManagementConnection, HttpClientManagementConnection>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<Auth0Middlware>();
                
            app.UseMiddleware<FacebookMiddlware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}