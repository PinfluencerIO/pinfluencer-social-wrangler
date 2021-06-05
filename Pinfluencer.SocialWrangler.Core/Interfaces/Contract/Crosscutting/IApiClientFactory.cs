using System;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface IApiClientFactory : IFactory
    {
        IApiClient Factory( Uri uri, string token );
    }
}