using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceGenderRepository : BubbleRepository<AudienceGenderRepository>, IAudienceGenderRepository
    {
        public AudienceGenderRepository( IBubbleClient bubbleClient, ILoggerAdapter<AudienceGenderRepository> logger ) : base( bubbleClient, logger )
        {
        }

        public OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAll( string audienceId ) =>
            GetRequest( ( ) => BubbleClient.Get<IEnumerable<AudienceGender>>( "audiencegender" ), 
            x => x.Select( x => new AudiencePercentage<GenderEnum>
            {
                Id = x.Id, Percentage = x.Percentage, Value = x.Name.Enumify<GenderEnum>( )
            } ),
            Enumerable.Empty<AudiencePercentage<GenderEnum>>( ) );

        public OperationResultEnum Create( AudiencePercentage<GenderEnum> audience ) =>
            CreateRequest( ( ) => BubbleClient.Post( "audiencegender", new AudienceGender
            {
                Audience = audience.Id,
                Id = audience.Id,
                Name = audience.Value.ToString( ),
                Percentage = audience.Percentage
            } ) );
    }
}