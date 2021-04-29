using System;

namespace Pinf.InstaService.Crosscutting.Web
{
    public class ApiClientFactory : IApiClientFactory
    {
        public IApiClient Create( Uri uri, string token )
        {
            return new ApiClient( new HttpClientAdapter( ), uri, token );
        }
    }
}