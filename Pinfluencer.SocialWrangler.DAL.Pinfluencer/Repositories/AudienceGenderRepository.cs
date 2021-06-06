using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class AudienceGenderRepository : IAudienceGenderRepository
    {
        private const string Resource = "audiencegender";

        private readonly IBubbleDataHandler<AudienceGenderRepository> _bubbleDataHandler;

        public AudienceGenderRepository( IBubbleDataHandler<AudienceGenderRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAll( string audienceId )
        {
            return _bubbleDataHandler
                .Read<IEnumerable<AudiencePercentage<GenderEnum>>, TypeResponse<BubbleCollection<AudienceGender>>>(
                    Resource, DataMap,
                    Enumerable.Empty<AudiencePercentage<GenderEnum>>( ) );
        }

        public OperationResultEnum Create( AudiencePercentage<GenderEnum> audience )
        {
            return _bubbleDataHandler.Create( Resource, audience, ModelMap );
        }

        public AudienceGender ModelMap( AudiencePercentage<GenderEnum> model )
        {
            return new AudienceGender
            {
                Audience = model.Audience.Id,
                Id = model.Id,
                Name = model.Value.ToString( ),
                Percentage = model.Percentage
            };
        }

        public IEnumerable<AudiencePercentage<GenderEnum>> DataMap(
            TypeResponse<BubbleCollection<AudienceGender>> data )
        {
            return data.Type.Results.Select( x => new AudiencePercentage<GenderEnum>
            {
                Id = x.Id, Percentage = x.Percentage, Value = x.Name.Enumify<GenderEnum>( ),
                Audience = new AudienceModel { Id = x.Audience }
            } );
        }
    }
}