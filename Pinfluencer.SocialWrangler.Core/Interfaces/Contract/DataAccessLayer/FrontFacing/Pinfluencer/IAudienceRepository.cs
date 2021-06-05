using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer
{
    public interface IAudienceRepository
    {
        OperationResultEnum Create( Audience audience );

        OperationResultEnum Update( Audience audience );
    }
}