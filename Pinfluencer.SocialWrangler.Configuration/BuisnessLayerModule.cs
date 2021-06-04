using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Auth0.AuthenticationApi;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Serialization;
using Pinfluencer.SocialWrangler.BLL;
using Pinfluencer.SocialWrangler.BLL.Facades;
using Pinfluencer.SocialWrangler.Configuration.Options;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Social;
using Pinfluencer.SocialWrangler.Crosscutting.AspNetCoreExtensions;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Factories;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class BuisnessLayerModule
    {
        [ Binding ]
        public static IServiceCollection Bind( IServiceCollection services )
        {
            MainInitializer.Initialize( );
            BllInitializer.Initialize( );
            return services;
        }
    }
}