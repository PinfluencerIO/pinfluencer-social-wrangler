using Aidan.Common.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer
{
    public interface IAudienceRepository
    {
        OperationResultEnum Create( Audience audience );

        OperationResultEnum Update( Audience audience );
    }
}