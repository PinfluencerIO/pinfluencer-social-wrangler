using System;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
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
        
        public SocialContentFacade( ISocialContentReachRepository socialContentReachRepository, IDateTimeAdapter dateTimeAdapter, ISocialContentImpressionsRepository impressionsRepository )
        {
            _socialContentReachRepository = socialContentReachRepository;
            _dateTimeAdapter = dateTimeAdapter;
            _impressionsRepository = impressionsRepository;
        }

        public ObjectResult<IEnumerable<ContentImpressions>> GetImpressions( string id )
        {
            return _impressionsRepository.Get( id,
                PeriodEnum.Day28,
                ( _dateTimeAdapter.Now( ).Subtract( new TimeSpan( 1, 0, 0, 0 ) ), _dateTimeAdapter.Now( ) ) );
        }
        
        public ObjectResult<IEnumerable<ContentReach>> GetReach( string id )
        {
            return _socialContentReachRepository.Get( id,
                PeriodEnum.Day28, (
                    _dateTimeAdapter
                        .Now( )
                        .Subtract( new TimeSpan( 1, 0, 0, 0 ) ),
                    _dateTimeAdapter
                        .Now( ) ) );
        }
    }
}