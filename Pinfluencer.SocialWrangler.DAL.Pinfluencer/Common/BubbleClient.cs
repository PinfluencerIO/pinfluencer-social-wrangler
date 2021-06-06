using System;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Crosscutting.Web;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common
{
    public class BubbleClient : ApiClientBase, IBubbleClient
    {
        public BubbleClient( IConfigurationAdapter configuration, ISerializer serializer, IHttpClient httpClient ) : base(
            httpClient, serializer )
        {
            var bubbleSettings = configuration
                .Get<AppOptions>( )
                .PinfluencerData;
            SetBaseUrl( new Uri( bubbleSettings.Domain ) );
            SetBearerToken( bubbleSettings.Secret );
        }
    }
}