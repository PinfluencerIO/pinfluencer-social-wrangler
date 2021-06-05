using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories
{
    public interface IAuthServiceAuthenticationClientDecoratorFactory : IFactory
    {
        IAuthServiceAuthenticationClientDecorator Factory( string domain );
    }
}