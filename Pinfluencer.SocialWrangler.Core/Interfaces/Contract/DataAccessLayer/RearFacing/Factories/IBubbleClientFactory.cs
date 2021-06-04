using System;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories
{
    public interface IBubbleClientFactory : IFactory
    {
        IBubbleClient Factory( string uri, string token );
    }
}