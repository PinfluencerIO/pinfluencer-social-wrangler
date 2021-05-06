using System;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.Options;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Factories;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Factories;
using Pinf.InstaService.DAL.Instagram.Repositories;
using Pinf.InstaService.DAL.Pinfluencer;
using Pinf.InstaService.DAL.Pinfluencer.Common;
using Pinf.InstaService.DAL.Pinfluencer.Factories;
using Pinf.InstaService.DAL.Pinfluencer.Repositories;

namespace Pinf.InstaService.API.InstaFetcher
{
    public class Startup
    {
        public void ConfigureServices( IServiceCollection dependancyCollection )
        {
            dependancyCollection
                .AddSingleton<CountryGetter>( )
                .AddScoped<Auth0Context>( )
                .AddScoped<FacebookContext>( )
                .AddTransient<IContractResolver, ClassicJsonResolver>( )
                .AddTransient<ISerializer, JsonSerialzierAdapter>( )
                .AddTransient<MvcAdapter>( )
                .AddTransient<IFacebookClientFactory, FacebookClientFactory>( )
                .AddTransient<IAuth0AuthenticationApiClientFactory, Auth0AuthenticationApiClientFactory>( )
                .AddTransient<IUserRepository, UserRepository>( )
                .AddTransient<ISocialImpressionsRepository, InstagramImpressionsRepository>( )
                .AddTransient<ISocialAudienceRepository, InstagramAudienceRepository>( )
                .AddTransient<ISocialUserRepository, InstagramUserRepository>( )
                .AddTransient<IManagementConnection, HttpClientManagementConnection>( )
                .AddTransient<IAuthenticationConnection, HttpClientAuthenticationConnection>( )
                .AddTransient<InstagramFacade>( )
                .AddTransient<SimpleAuthActionFilter>( )
                .AddTransient<FacebookActionFilter>( )
                .AddTransient<Auth0ActionFilter>( )
                .AddTransient<IHttpClient, HttpClientAdapter>( )
                .AddTransient<IBubbleClient>( provider =>
                {
                    var bubbleSettings = provider.GetService<IConfiguration>( ).Get<AppOptions>( );
                    return new BubbleClient( provider.GetService<IHttpClient>( ),
                        new Uri( bubbleSettings.Bubble.Domain ), bubbleSettings.Bubble.Secret );
                } )
                .AddTransient<IDateTimeAdapter, DateTimeAdapter>( )
                .AddTransient<IUser, User>( )
                .AddTransient<InfluencerFacade>( )
                .AddTransient( typeof( ILoggerAdapter<> ), typeof( LoggerAdapter<> ) )
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