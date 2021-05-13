using System;

namespace Pinfluencer.SocialWrangler.Crosscutting.Web
{
    public interface IApiClientFactory
    {
        IApiClient Create( Uri uri, string token );
    }
}