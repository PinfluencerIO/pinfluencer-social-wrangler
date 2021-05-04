using System.Collections.Generic;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceGenderRepository : IAudienceGenderRepository
    {
        public OperationResult<IEnumerable<GenderEnum>> GetAll( string audienceId )
        {
            throw new System.NotImplementedException( );
        }

        public OperationResultEnum Create( GenderEnum audience ) { throw new System.NotImplementedException( ); }
    }
}