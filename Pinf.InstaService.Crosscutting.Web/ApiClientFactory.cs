using System;

namespace Pinf.InstaService.Crosscutting.Web
{
    public class ApiClientFactory : IApiClientFactory
    {
        public IApiClient Create( Uri uri, string token ) => new ApiClient( new HttpClientAdapter( ), uri, token );
    }
}