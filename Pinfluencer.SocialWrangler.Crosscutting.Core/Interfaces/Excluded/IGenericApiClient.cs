using System;
using System.Net;

namespace Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Excluded
{
    public interface IGenericApiClient
    {
        void SetBaseUrl( Uri uri );
        void SetBearerToken( string token );
        HttpStatusCode Patch<T>( string uri, T body );
        ( HttpStatusCode, T ) Get<T>( string uri );
        HttpStatusCode Post<T>( string uri, T body );
    }
}