using System;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public class ApiClient : ApiClientBase, IApiClient
    {
        public ApiClient( Uri uri, string token, ISerializer serializer, IHttpClient httpClient ) : base( uri, token,
            serializer, httpClient )
        {
        }
    }
}