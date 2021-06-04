using System;
using System.Net;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public abstract class ApiClientBase : IGenericApiClient
    {
        protected readonly IHttpClient HttpClient;
        protected readonly ISerializer Serializer;

        protected ApiClientBase( IHttpClient httpClient, ISerializer serializer )
        {
            HttpClient = httpClient;
            Serializer = serializer;
        }
        
        protected ApiClientBase( Uri uri, string token, ISerializer serializer, IHttpClient httpClient ) : this( httpClient, serializer )
        {
            SetBaseUrl( uri );
            SetBearerToken( token );
        }

        public void SetBaseUrl( Uri uri ) { HttpClient.SetBaseUrl( uri ); }
        public void SetBearerToken( string token ) { HttpClient.SetBearerToken( token ); }

        public HttpStatusCode Patch<T>( string uri, T body )
        {
            return HttpClient.Patch( uri, Serializer.Serialize( body ) ).StatusCode;
        }

        public( HttpStatusCode, T ) Get<T>( string uri )
        {
            var result = HttpClient.Get( uri );
            return( result.StatusCode, Serializer.Deserialize<T>( result.Content.ReadAsStringAsync( ).Result ) );
        }

        public HttpStatusCode Post<T>( string uri, T body )
        {
            return HttpClient.Post( uri, Serializer.Serialize( body ) ).StatusCode;
        }
    }
}