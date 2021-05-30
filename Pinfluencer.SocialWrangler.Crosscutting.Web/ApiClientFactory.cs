using System;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public class ApiClientFactory : IApiClientFactory
    {
        private readonly ISerializer _serializer;

        public ApiClientFactory( ISerializer serializer ) { _serializer = serializer; }
        
        public IApiClient Create( Uri uri, string token )
        {
            return new ApiClient( new HttpClientAdapter( ), uri, token, _serializer );
        }
    }
}