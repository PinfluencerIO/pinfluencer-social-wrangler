using Pinfluencer.SocialWrangler.Core.Interfaces;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories
{
    public interface IFacebookClientFactory : IFactory
    {
        public IFacebookClientAdapter Factory( string token );
    }
}