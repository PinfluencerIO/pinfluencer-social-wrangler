using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class AudienceAgeRepository : IAudienceAgeRepository
    {
        private const string Resource = "audienceage";
        private readonly IBubbleDataHandler<AudienceAgeRepository> _bubbleDataHandler;

        public AudienceAgeRepository( IBubbleDataHandler<AudienceAgeRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAll( string audienceId )
        {
            return _bubbleDataHandler
                .Read<IEnumerable<AudiencePercentage<AgeProperty>>, TypeResponse<BubbleCollection<AudienceAge>>>(
                    Resource,
                    x =>
                    {
                        return x.Type.Results.Select( y =>
                        {
                            var range = y.Range;
                            var rangeSplit = range.Split( "-" );
                            return new AudiencePercentage<AgeProperty>
                            {
                                Audience = new AudienceModel { Id = y.Audience },
                                Id = y.Id,
                                Percentage = y.Percentage,
                                Value = new AgeProperty
                                    { Min = int.Parse( rangeSplit[ 0 ] ), Max = int.Parse( rangeSplit[ 1 ] ) }
                            };
                        } );
                    }, Enumerable.Empty<AudiencePercentage<AgeProperty>>( ) );
        }

        public OperationResultEnum Create( AudiencePercentage<AgeProperty> audience )
        {
            return _bubbleDataHandler.Create( Resource, audience, ModelMap );
        }

        public AudienceAge ModelMap( AudiencePercentage<AgeProperty> audienceAge )
        {
            return new AudienceAge
            {
                Audience = audienceAge.Audience.Id,
                Id = audienceAge.Id,
                Percentage = audienceAge.Percentage,
                Range = $"{audienceAge.Value.Min}-{audienceAge.Value.Max}"
            };
        }

        public IEnumerable<AudiencePercentage<AgeProperty>> DataMap(
            TypeResponse<BubbleCollection<AudienceAge>> audienceAge )
        {
            return audienceAge.Type.Results.Select( y =>
            {
                var range = y.Range;
                var rangeSplit = range.Split( "-" );
                return new AudiencePercentage<AgeProperty>
                {
                    Audience = new AudienceModel { Id = y.Audience },
                    Id = y.Id,
                    Percentage = y.Percentage,
                    Value = new AgeProperty { Min = int.Parse( rangeSplit[ 0 ] ), Max = int.Parse( rangeSplit[ 1 ] ) }
                };
            } );
        }
    }
}