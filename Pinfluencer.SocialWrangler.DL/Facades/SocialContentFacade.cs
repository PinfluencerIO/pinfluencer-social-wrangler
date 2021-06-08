using System;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class SocialContentFacade : ISocialContentFacade
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;
        private readonly ISocialContentReachRepository _socialContentReachRepository;
        private readonly ISocialContentImpressionsRepository _impressionsRepository;
        private readonly ISocialContentRepository _socialContentRepository;
        private readonly ISocialInsightUserFacade _insightsSocialUserFacade;
        private readonly ISocialEngagementRepository _socialEngagementRepository;
        
        public SocialContentFacade( ISocialContentReachRepository socialContentReachRepository,
            IDateTimeAdapter dateTimeAdapter,
            ISocialContentImpressionsRepository impressionsRepository,
            ISocialContentRepository socialContentRepository,
            ISocialInsightUserFacade insightsSocialUserFacade,
            ISocialEngagementRepository socialEngagementRepository )
        {
            _socialContentReachRepository = socialContentReachRepository;
            _dateTimeAdapter = dateTimeAdapter;
            _impressionsRepository = impressionsRepository;
            _socialContentRepository = socialContentRepository;
            _insightsSocialUserFacade = insightsSocialUserFacade;
            _socialEngagementRepository = socialEngagementRepository;
        }

        public ObjectResult<int> GetImpressions( string id )
        {
            var result = _impressionsRepository.Get( id,
                PeriodEnum.Day28,
                ( _dateTimeAdapter.Now( ).Subtract( new TimeSpan( 1, 0, 0, 0 ) ), _dateTimeAdapter.Now( ) ) );
            return result.Status == OperationResultEnum.Failed
                ? new ObjectResult<int>
                {
                    Status = OperationResultEnum.Failed,
                    Value = default
                }
                : new ObjectResult<int>
                {
                    Status = OperationResultEnum.Success,
                    Value = result.Value.First().Count
                };
        }
        
        public ObjectResult<int> GetReach( string id )
        {
            var result = _socialContentReachRepository.Get( id,
                PeriodEnum.Day28, (
                    _dateTimeAdapter
                        .Now( )
                        .Subtract( new TimeSpan( 1, 0, 0, 0 ) ),
                    _dateTimeAdapter
                        .Now( ) ) );
            return result.Status == OperationResultEnum.Failed
                ? new ObjectResult<int>
                {
                    Status = OperationResultEnum.Failed,
                    Value = default
                }
                : new ObjectResult<int>
                {
                    Status = OperationResultEnum.Success,
                    Value = result
                        .Value
                        .First( )
                        .Count
                };
        }

        public ObjectResult<double> GetEngagementRate( )
        {
            var user = _insightsSocialUserFacade
                .GetUsers( )
                .Value
                .First( );
            var contentCollection = _socialContentRepository
                .GetAll( user.Id )
                .Value;
            var collection = contentCollection
                .Where( x => x.TimeOfUpload > _dateTimeAdapter
                    .Now( )
                    .Subtract( new TimeSpan( 28, 0, 0, 0 ) ) )
                .ToArray(  );
            double engagements = collection
                .Sum( x => engagementSelector( x, user ) );

            engagements /= collection.Count();

            return new ObjectResult<double>
            {
                Status = OperationResultEnum.Success,
                Value = Math.Round( engagements, 4 )
            };
        }

        private double engagementSelector( Content content, SocialInsightsUser user )
        {
            return _socialEngagementRepository
                .Get( content.Id )
                .Value / ( double ) user.Followers;
        }
    }
}