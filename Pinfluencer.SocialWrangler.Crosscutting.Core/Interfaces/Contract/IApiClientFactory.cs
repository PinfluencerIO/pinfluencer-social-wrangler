using System;
using Pinfluencer.SocialWrangler.Core;

namespace Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract
{
    public interface IApiClientFactory : IFactory
    {
        IApiClient Factory( Uri uri, string token );
    }
}