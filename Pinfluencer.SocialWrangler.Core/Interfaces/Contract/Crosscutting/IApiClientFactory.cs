using System;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.Crosscutting;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface IApiClientFactory : IFactory
    {
        IApiClient Factory( Uri uri, string token );
    }
}