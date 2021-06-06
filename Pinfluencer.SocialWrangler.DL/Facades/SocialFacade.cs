using System;
using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class SocialFacade : ISocialFacade
    {
        private readonly ISocialContentImpressionsRepository _impressionsRepository;
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;
        private readonly IDateTimeAdapter _dateTimeAdapter;
        private readonly ISocialAudienceGenderAgeRepository _socialAudienceGenderAgeRepository;
        private readonly ISocialAudienceCountryRepository _socialAudienceCountryRepository;

        public SocialFacade(
            ISocialContentImpressionsRepository impressionsRepository,
            IInsightsSocialUserRepository insightsSocialUserRepository,
            IDateTimeAdapter dateTimeAdapter,
            ISocialAudienceGenderAgeRepository socialAudienceGenderAgeRepository,
            ISocialAudienceCountryRepository socialAudienceCountryRepository )
        {
            _impressionsRepository = impressionsRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
            _dateTimeAdapter = dateTimeAdapter;
            _socialAudienceGenderAgeRepository = socialAudienceGenderAgeRepository;
            _socialAudienceCountryRepository = socialAudienceCountryRepository;
        }

        public ObjectResult<IEnumerable<ContentImpressions>> GetMonthlyProfileViews( string id )
        {
            return _impressionsRepository.Get( id,
                PeriodEnum.Day28,
                ( _dateTimeAdapter.Now( ).Subtract( new TimeSpan( 1, 0, 0, 0 ) ), _dateTimeAdapter.Now( ) ) );
        }

        //TODO: MOVE BUSINESS RULES OUT OF DATA LAYER ( NUMBER OF USERS RETURNED SHOULDN'T CONCERN DATA LAYER )
        public ObjectResult<IEnumerable<SocialInsightsUser>> GetUsers( )
        {
            return _insightsSocialUserRepository.GetAll( );
        }

        public ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>> GetAudienceCountryInsights(
            string id )
        {
            var result = _socialAudienceCountryRepository.Get( id );
            if( result.Status != OperationResultEnum.Success )
                return new ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>>(
                    Enumerable.Empty<AudiencePercentage<CountryProperty>>( ), OperationResultEnum.Failed );

            var totalFollowers = result.Value.Sum( x => x.Count );
            return new ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>>(
                result.Value.Select( x => new AudiencePercentage<CountryProperty>
                    { Percentage = ( double ) x.Count / ( double ) totalFollowers, Value = x.Property } ),
                OperationResultEnum.Success );
        }

        public ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id )
        {
            var result = _socialAudienceGenderAgeRepository.Get( id );
            if( result.Status != OperationResultEnum.Success )
                return new ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                    Enumerable.Empty<AudiencePercentage<GenderEnum>>( ), OperationResultEnum.Failed );

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.Gender )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<GenderEnum>
                    { Percentage = ( double ) x.Item2 / totalFollowers, Value = x.Key } ),
                OperationResultEnum.Success );
        }

        public ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id )
        {
            var result = _socialAudienceGenderAgeRepository.Get( id );
            if( result.Status != OperationResultEnum.Success )
                return new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                    Enumerable.Empty<AudiencePercentage<AgeProperty>>( ), OperationResultEnum.Failed );

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.AgeRange )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<AgeProperty>
                {
                    Percentage = ( double ) x.Item2 / totalFollowers,
                    Value = new AgeProperty { Max = x.Key.Item2, Min = x.Key.Item1 }
                } ),
                OperationResultEnum.Success );
        }
    }
}