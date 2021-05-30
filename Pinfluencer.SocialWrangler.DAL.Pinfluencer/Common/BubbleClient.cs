using System;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common
{
    public class BubbleClient : ApiClient, IBubbleClient
    {
        public BubbleClient( IHttpClient httpClient, Uri uri, string token, ISerializer serializer ) : base( httpClient, uri, token, serializer ) { }
    }
}