using System;

namespace Pinf.InstaService.Crosscutting.Web
{
    public interface IApiClientFactory
    {
        IApiClient Create( Uri uri, string token );
    }
}