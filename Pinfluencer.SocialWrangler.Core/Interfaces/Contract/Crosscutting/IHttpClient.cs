using System;
using System.Net.Http;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface IHttpClient
    {
        void SetBaseUrl( Uri uri );
        void SetBearerToken( string token );
        HttpResponseMessage Patch( string uri, string body );
        HttpResponseMessage Get( string uri );
        HttpResponseMessage Post( string uri, string body );
    }
}