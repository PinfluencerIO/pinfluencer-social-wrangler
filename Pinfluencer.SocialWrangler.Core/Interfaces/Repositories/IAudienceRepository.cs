using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface IAudienceRepository
    {
        OperationResultEnum Create( Audience audience );
        
        OperationResultEnum Update( Audience audience );
    }
}