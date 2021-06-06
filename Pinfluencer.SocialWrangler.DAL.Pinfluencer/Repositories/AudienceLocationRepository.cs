using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class AudienceLocationRepository : IAudienceLocationRepository
    {
        private readonly IBubbleDataHandler<AudienceLocationRepository> _bubbleDataHandler;

        public AudienceLocationRepository( IBubbleDataHandler<AudienceLocationRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public ObjectResult<IEnumerable<AudiencePercentage<LocationProperty>>> GetAll( string audienceId )
        {
            return _bubbleDataHandler
                .Read<IEnumerable<AudiencePercentage<LocationProperty>>,
                    TypeResponse<BubbleCollection<AudienceLocation>>>( "audiencelocation",
                    DataMap, Enumerable.Empty<AudiencePercentage<LocationProperty>>( ) );
        }

        public OperationResultEnum Create( AudiencePercentage<LocationProperty> audience )
        {
            return _bubbleDataHandler.Create( "audiencelocation", audience, ModelMap );
        }

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

        public IEnumerable<AudiencePercentage<LocationProperty>>
            DataMap( TypeResponse<BubbleCollection<AudienceLocation>> audienceLocation )
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