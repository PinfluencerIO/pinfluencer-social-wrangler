using System;
using Microsoft.Extensions.Configuration;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.Crosscutting.Web;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common
{
    public class BubbleClient : ApiClientBase, IBubbleClient
    {
        public BubbleClient( IConfiguration configuration, ISerializer serializer, IHttpClient httpClient ) : base(
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