using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.Configuration;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

namespace Pinfluencer.SocialWrangler.API
{
    public class Startup
    {
        public void ConfigureServices( IServiceCollection services )
        {
            services
                .BindApplicationServices( )
                .AddTransient<Auth0ActionFilter>( )
                .AddTransient<FacebookActionFilter>( )
                .AddTransient<SimpleAuthActionFilter>( )
                .AddTransient<MvcAdapter>( )
                .AddTransient<IAuthenticationConnection, HttpClientAuthenticationConnection>( )
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