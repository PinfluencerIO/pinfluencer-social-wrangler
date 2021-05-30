using System;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.API.Options;
using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Factories;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Factories;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.API
{
    public class Startup
    {
        public void ConfigureServices( IServiceCollection dependancyCollection )
        {
            dependancyCollection
                .AddSingleton<CountryGetter>( )
                .AddScoped<Auth0Context>( )
                .AddScoped<IFacebookDecorator,FacebookDecorator>( )
                .AddTransient<IContractResolver, PinfluencerJsonResolver>( )
                .AddTransient<ISerializer, JsonSerialzierAdapter>( )
                .AddTransient<MvcAdapter>( )
                .AddTransient<IFacebookClientAdapter,FacebookClientAdapter>( )
                .AddTransient<IFacebookClientFactory, FacebookClientFactory>( )
                .AddTransient<IAuth0AuthenticationApiClientFactory, Auth0AuthenticationApiClientFactory>( )
                .AddTransient<IUserRepository, UserRepository>( )
                .AddTransient<ISocialImpressionsRepository, InstagramImpressionsRepository>( )
                .AddTransient<ISocialAudienceRepository, InstagramAudienceRepository>( )
                .AddTransient<IInsightsSocialUserRepository, InstagramUserRepository>( )
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
                        new Uri( bubbleSettings.Bubble.Domain ), bubbleSettings.Bubble.Secret, provider.GetService<ISerializer>( ) );
                } )
                .AddTransient( typeof( IBubbleDataHandler<> ), typeof( BubbleDataHandler<> ) )
                .AddTransient( typeof( IFacebookDataHandler<> ), typeof( FacebookDataHandler<> ) )
                .AddTransient<IDateTimeAdapter, DateTimeAdapter>( )
                .AddTransient<ISocialInfoUser, SocialInfoUser>( )
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