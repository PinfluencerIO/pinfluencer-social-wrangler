using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Facebook;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public static class DataAccessModule
    {
        [ Binding ]
        public static IServiceCollection Bind( IServiceCollection services )
        {
            MainInitializer.Initialize( );
            DalUtilsInitializer.Initialize( );
            DalFacebookInitializer.Initialize( );
            DalPinfluencerInitializer.Initialize( );
            return services;
        }
    }
}