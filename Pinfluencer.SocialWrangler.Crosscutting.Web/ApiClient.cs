using System;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.Crosscutting;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public class ApiClient : ApiClientBase, IApiClient
    {
        public ApiClient( Uri uri, string token, ISerializer serializer, IHttpClient httpClient ) : base( uri, token, serializer, httpClient )
        {
        }
    }
}