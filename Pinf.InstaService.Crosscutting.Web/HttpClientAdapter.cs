using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Pinf.InstaService.Crosscutting.Web
{
    public class HttpClientAdapter : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientAdapter( ) { _httpClient = new HttpClient( ); }

        public void SetBaseUrl( Uri uri ) { _httpClient.BaseAddress = uri; }

        public void SetBearerToken( string token )
        {
            _httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue( "Bearer", token );
        }

        public HttpResponseMessage Patch( string uri, string body )
        {
            return _httpClient.PatchAsync( uri, new StringContent( body ) ).Result;
        }

        public HttpResponseMessage Get( string uri ) { return _httpClient.GetAsync( uri ).Result; }

        public HttpResponseMessage Post( string uri, string body )
        {
            return _httpClient.PostAsync( uri, new StringContent( body ) ).Result;
        }
    }
}