using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;
using Pinf.InstaService.DAL.Core.Interfaces.Handlers;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceAgeRepository : IAudienceAgeRepository
    {
        private readonly IBubbleDataHandler<AudienceAgeRepository> _bubbleDataHandler;
        private const string Resource = "audienceage";

        public AudienceAgeRepository( IBubbleDataHandler<AudienceAgeRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAll( string audienceId ) =>
            new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                Enumerable.Empty<AudiencePercentage<AgeProperty>>( ), OperationResultEnum.Failed );

        public OperationResultEnum Create( AudiencePercentage<AgeProperty> audience ) =>
            _bubbleDataHandler.Create( Resource, audience, ModelMap );

        public AudienceAge ModelMap( AudiencePercentage<AgeProperty> audienceAge ) =>
            new AudienceAge
            {
                Audience = audienceAge.Audience.Id,
                Id = audienceAge.Id,
                Percentage = audienceAge.Percentage,
                Range = $"{audienceAge.Value.Min}-{audienceAge.Value.Max}"
            };
    }
}