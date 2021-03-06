using Aidan.Common.Core.Enum;
using Aidan.Common.Utils.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.Crosscutting.DIModule;
using Pinfluencer.SocialWrangler.DAL.DIModule;
using Pinfluencer.SocialWrangler.DL.DIModule;

namespace Pinfluencer.SocialWrangler.API
{
    public class Startup
    {
        public void ConfigureServices( IServiceCollection services )
        {
            services
                .BindCrosscuttingLayer( )
                .BindDomainLayer( )
                .BindDataAcessLayer( )
                .AddTransient<Auth0ActionFilter>( )
                .AddTransient<FacebookActionFilter>( )
                .AddTransient<SimpleAuthActionFilter>( )
                .AddTransient<MvcAdapter>( )
                .AddControllers( )
                .BindJsonOptions( CaseEnum.Snake );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment( ) ) app.UseDeveloperExceptionPage( );

            app.UseRouting( );

            app.UseEndpoints( endpoints => endpoints.MapControllers( ) );
        }
    }
}