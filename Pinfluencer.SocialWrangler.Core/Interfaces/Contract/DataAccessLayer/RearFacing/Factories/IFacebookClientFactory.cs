using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories
{
    public interface IFacebookClientFactory : IFactory
    {
        public IFacebookClientAdapter Factory( string token );
    }
}