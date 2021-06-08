using System;
using Pinfluencer.SocialWrangler.Core.Interfaces;

namespace Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract
{
    public interface IApiClientFactory : IFactory
    {
        IApiClient Factory( Uri uri, string token );
    }
}