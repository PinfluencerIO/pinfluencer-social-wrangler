using System;
using System.Net;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public class ApiClient : IApiClient
    {
        private readonly IHttpClient _httpClient;
        private readonly ISerializer _serializer;

        private ApiClient( IHttpClient httpClient, ISerializer serializer )
        {
            _httpClient = httpClient;
            _serializer = serializer;
        }

        public ApiClient( IHttpClient httpClient, Uri uri, string token, ISerializer serializer ) : this( httpClient, serializer )
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