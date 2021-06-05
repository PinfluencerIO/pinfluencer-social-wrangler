using Pinfluencer.SocialWrangler.Core.Attributes;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients
{
    [ Service( Scope = ServiceLifetimeEnum.Scoped ) ]
    public interface IAuthServiceManagementClientDecorator
    {
        public string Secret { set; }
    
        string GetIdentityToken( string id );
    }
}