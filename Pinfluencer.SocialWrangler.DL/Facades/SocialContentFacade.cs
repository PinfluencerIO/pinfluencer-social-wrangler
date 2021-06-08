﻿using System;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
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
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;
        private readonly ISocialEngagementRepository _socialEngagementRepository;
        
        public SocialContentFacade( ISocialContentReachRepository socialContentReachRepository, IDateTimeAdapter dateTimeAdapter, ISocialContentImpressionsRepository impressionsRepository, ISocialContentRepository socialContentRepository, IInsightsSocialUserRepository insightsSocialUserRepository, ISocialEngagementRepository socialEngagementRepository )
        {
            _socialContentReachRepository = socialContentReachRepository;
            _dateTimeAdapter = dateTimeAdapter;
            _impressionsRepository = impressionsRepository;
            _socialContentRepository = socialContentRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
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
            var user = _insightsSocialUserRepository
                .GetAll( )
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
                .Sum( content => _socialEngagementRepository
                    .Get( content.Id )
                    .Value / ( double ) user.Followers );

            engagements /= collection.Count();

            return new ObjectResult<double>
            {
                Status = OperationResultEnum.Success,
                Value = engagements
            };
        }
    }
}