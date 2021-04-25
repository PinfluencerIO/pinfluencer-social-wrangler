using System;
using System.Net.Http;

namespace Pinf.InstaService.Crosscutting.Web
{
    public class HttpClientAdapter : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientAdapter( )
        {
            _httpClient = new HttpClient();
        }

        public HttpResponseMessage Patch( Uri uri, string body )
        {
            return _httpClient.PatchAsync( uri, new StringContent( body ) ).Result;
        }
    }
}