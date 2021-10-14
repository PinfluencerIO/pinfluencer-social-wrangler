using Aidan.Common.Core.Attributes;
using Aidan.Common.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients
{
    [ Service( Scope = ServiceLifetimeEnum.Scoped ) ]
    public interface IAuthServiceManagementClientDecorator
    {
        public string Secret { set; }
    
        string GetIdentityToken( string id );
    }
}