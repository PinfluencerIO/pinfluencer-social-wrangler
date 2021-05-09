using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceLocationRepository : IAudienceLocationRepository
    {
        private readonly IBubbleDataHandler<AudienceLocationRepository> _bubbleDataHandler;

        public AudienceLocationRepository( IBubbleDataHandler<AudienceLocationRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>>GetAll( string audienceId ) =>
            _bubbleDataHandler
                .Read<IEnumerable<AudiencePercentage<LocationProperty>>,
                    TypeResponse<BubbleCollection<AudienceLocation>>>( "audiencelocation",
                    DataMap, Enumerable.Empty<AudiencePercentage<LocationProperty>>( ) );

        public OperationResultEnum Create( AudiencePercentage<LocationProperty> audience ) =>
            _bubbleDataHandler.Create( "audiencelocation", audience, ModelMap );

        //TODO: ADD COUNTRY MAPPING
        public AudienceLocation ModelMap( AudiencePercentage<LocationProperty> audienceLocation )
        {
            return new AudienceLocation
            {
                Audience = audienceLocation.Audience.Id,
                Id = audienceLocation.Id,
                Percentage = audienceLocation.Percentage,
                Place = ""
            };
        }

        public IEnumerable<AudiencePercentage<LocationProperty>> DataMap( TypeResponse<BubbleCollection<AudienceLocation>> audienceLocation )
        {
            return audienceLocation.Type.Results.Select( y => new AudiencePercentage<LocationProperty>
            {
                Audience = new AudienceModel
                {
                    Id = y.Audience
                },
                Id = y.Id,
                Percentage = y.Percentage,
                Value = new LocationProperty { Country = y.Place }
            } );
        }
    }
}