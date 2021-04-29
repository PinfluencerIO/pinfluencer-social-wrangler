using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.BLL.InstagramFetcher.Services;
using Pinf.InstaService.Core.Interfaces.Factories;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.DAL.Common;
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
                .AddTransient<IUserRepository, UserRepository>( )
                .AddTransient<IInstaImpressionsRepository, InstagramImpressionsRepository>( )
                .AddTransient<IInstaUserRepository, InstagramUserRepository>( )
                .AddTransient<IManagementConnection, HttpClientManagementConnection>( )
                .AddTransient<IAuthenticationConnection, HttpClientAuthenticationConnection>( )
                .AddTransient<InstagramFacade>( )
                .AddTransient<SimpleAuthActionFilter>( )
                .AddTransient<FacebookActionFilter>( )
                .AddTransient<Auth0ActionFilter>( )
                .AddControllers( );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment( ) ) app.UseDeveloperExceptionPage( );

            app.UseRouting( );

            app.UseEndpoints( endpoints => endpoints.MapControllers( ) );
        }
    }
}