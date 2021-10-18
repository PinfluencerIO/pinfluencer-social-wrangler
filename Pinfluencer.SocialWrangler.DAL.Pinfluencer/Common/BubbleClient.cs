using System;
using Aidan.Common.Core.Interfaces.Contract;
using Aidan.Common.Utils.Web;
using Pinfluencer.SocialWrangler.Core.Options;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common
{
    public class BubbleClient : ApiClientBase<IJsonSnakeCaseSerializer>, IBubbleClient
    {
        public BubbleClient( IConfigurationAdapter configuration, IJsonSnakeCaseSerializer serializer, IHttpClient httpClient ) : base(
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