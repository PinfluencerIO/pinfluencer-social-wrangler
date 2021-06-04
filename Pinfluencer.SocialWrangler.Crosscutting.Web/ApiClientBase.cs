using System;
using System.Net;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public abstract class ApiClientBase : IGenericApiClient
    {
        private readonly IHttpClient _httpClient;
        private readonly ISerializer _serializer;

        protected ApiClientBase( IHttpClient httpClient, ISerializer serializer )
        {
            _httpClient = httpClient;
            _serializer = serializer;
        }
        
        protected ApiClientBase( Uri uri, string token, ISerializer serializer, IHttpClient httpClient ) : this( httpClient, serializer )
        {
            SetBaseUrl( uri );
            SetBearerToken( token );
        }

        public void SetBaseUrl( Uri uri ) { _httpClient.SetBaseUrl( uri ); }
        public void SetBearerToken( string token ) { _httpClient.SetBearerToken( token ); }

        public HttpStatusCode Patch<T>( string uri, T body )
        {
            return _httpClient.Patch( uri, _serializer.Serialize( body ) ).StatusCode;
        }

        public( HttpStatusCode, T ) Get<T>( string uri )
        {
            var result = _httpClient.Get( uri );
            return( result.StatusCode, _serializer.Deserialize<T>( result.Content.ReadAsStringAsync( ).Result ) );
        }

        public HttpStatusCode Post<T>( string uri, T body )
        {
            return _httpClient.Post( uri, _serializer.Serialize( body ) ).StatusCode;
        }
    }
}