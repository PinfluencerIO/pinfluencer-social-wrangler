using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;
using Pinf.InstaService.DAL.Pinfluencer.Common;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceGenderRepository : IAudienceGenderRepository
    {
        private const string Resource = "audiencegender";
        
        private readonly IBubbleDataHandler<AudienceGenderRepository> _bubbleDataHandler;
        public AudienceGenderRepository( IBubbleDataHandler<AudienceGenderRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAll( string audienceId ) =>
            _bubbleDataHandler.Read<IEnumerable<AudiencePercentage<GenderEnum>>,IEnumerable<AudienceGender>>( Resource, 
                x => x.Select( x => new AudiencePercentage<GenderEnum> 
                    { Id = x.Id, Percentage = x.Percentage, Value = x.Name.Enumify<GenderEnum>( ) } ), 
                Enumerable.Empty<AudiencePercentage<GenderEnum>>( ) );

        public OperationResultEnum Create( AudiencePercentage<GenderEnum> audience ) =>
            _bubbleDataHandler.Create( Resource, audience, ModelMap );

        public AudienceGender ModelMap( AudiencePercentage<GenderEnum> model ) =>
            new AudienceGender
            {
                Audience = model.Audience.Id,
                Id = model.Id,
                Name = model.Value.ToString( ),
                Percentage = model.Percentage
            };
    }
}