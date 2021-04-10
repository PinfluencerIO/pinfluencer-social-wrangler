using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pinf.InstaService.API.InstaFetcher.Middleware;
using Pinf.InstaService.BLL.InstagramFetcher.Services;
using Pinf.InstaService.Bootstrapping.Services.Factories;
using Pinf.InstaService.Bootstrapping.Services.Repositories;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Factories;
using Pinf.InstaService.DAL.Instagram.Repositories;
using Pinf.InstaService.DAL.UserManagement;
using Pinf.InstaService.DAL.UserManagement.Factories;
using Pinf.InstaService.DAL.UserManagement.Repositories;

namespace Pinf.InstaService.API.InstaFetcher
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Auth0Context>();
            services.AddScoped<FacebookContext>();

            services.AddTransient<IFacebookClientFactory, FacebookClientFactory>();
            services.AddTransient<IAuth0AuthenticationApiClientFactory, Auth0AuthenticationApiClientFactory>();

            services.AddTransient<IUserRepository, Auth0UserRepository>();
            services.AddTransient<IInstaImpressionsRepository, FacebookInstaImpressionsRepository>();
            services.AddTransient<IInstaUserRepository, FacebookInstaUserRepository>();

            services.AddTransient<IManagementConnection, HttpClientManagementConnection>();
            services.AddTransient<IAuthenticationConnection, HttpClientAuthenticationConnection>();

            services.AddTransient<InstaUserService>();
            services.AddTransient<InstaInsightsCollectionService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            
            app.UseRouting();
            
            app.UseMiddleware<SimpleAuthenticationMiddleware>()
                .UseMiddleware<Auth0Middlware>()
                .UseMiddleware<FacebookMiddlware>();
   
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}