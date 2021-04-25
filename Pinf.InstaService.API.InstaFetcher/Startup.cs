using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.Middleware;
using Pinf.InstaService.BLL.Core.Factories;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.BLL.InstagramFetcher.Services;
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
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddScoped<Auth0Context>( )
                .AddScoped<FacebookContext>( )
                .AddTransient<IFacebookClientFactory, FacebookClientFactory>( )
                .AddTransient<IAuth0AuthenticationApiClientFactory, Auth0AuthenticationApiClientFactory>( )
                .AddTransient<IUserRepository, Auth0UserRepository>( )
                .AddTransient<IInstaImpressionsRepository, FacebookInstaImpressionsRepository>( )
                .AddTransient<IInstaUserRepository, FacebookInstaUserRepository>( )
                .AddTransient<IManagementConnection, HttpClientManagementConnection>( )
                .AddTransient<IAuthenticationConnection, HttpClientAuthenticationConnection>( )
                .AddTransient<InstagramFacade>( )
                .AddTransient<SimpleAuthAttribute>( )
                .AddTransient<FacebookAttribute>()
                .AddControllers( );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment( ) ) app.UseDeveloperExceptionPage( );

            app.UseRouting( );

            app.UseMiddleware<Auth0Middlware>( );

            app.UseEndpoints( endpoints => endpoints.MapControllers( ) );
        }
    }
}