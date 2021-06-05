﻿using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class InstagramFacade : IInstagramFacade
    {
        private readonly ISocialImpressionsRepository _impressionsRepository;
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;
        private readonly ISocialAudienceRepository _socialAudienceRepository;

        public InstagramFacade(
            ISocialImpressionsRepository impressionsRepository,
            IInsightsSocialUserRepository insightsSocialUserRepository,
            ISocialAudienceRepository socialAudienceRepository )
        {
            _impressionsRepository = impressionsRepository;
            _insightsSocialUserRepository = insightsSocialUserRepository;
            _socialAudienceRepository = socialAudienceRepository;
        }

        public OperationResult<IEnumerable<ContentImpressions>> GetMonthlyProfileViews( string id )
        {
            return _impressionsRepository.Get( id );
        }

        //TODO: MOVE BUSINESS RULES OUT OF DATA LAYER ( NUMBER OF USERS RETURNED SHOULDN'T CONCERN DATA LAYER )
        public OperationResult<IEnumerable<SocialInsightsUser>> GetUsers( )
        {
            return _insightsSocialUserRepository.GetAll( );
        }

        public OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>> GetAudienceCountryInsights(
            string id )
        {
            var result = _socialAudienceRepository.GetCountry( id );
            if( result.Status != OperationResultEnum.Success )
                return new OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>>(
                    Enumerable.Empty<AudiencePercentage<LocationProperty>>( ), OperationResultEnum.Failed );

            var totalFollowers = result.Value.Sum( x => x.Count );
            return new OperationResult<IEnumerable<AudiencePercentage<LocationProperty>>>(
                result.Value.Select( x => new AudiencePercentage<LocationProperty>
                    { Percentage = ( double ) x.Count / ( double ) totalFollowers, Value = x.Property } ),
                OperationResultEnum.Success );
        }

        public OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id )
        {
            var result = _socialAudienceRepository.GetGenderAge( id );
            if( result.Status != OperationResultEnum.Success )
                return new OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                    Enumerable.Empty<AudiencePercentage<GenderEnum>>( ), OperationResultEnum.Failed );

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.Gender )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<GenderEnum>
                    { Percentage = ( double ) x.Item2 / totalFollowers, Value = x.Key } ),
                OperationResultEnum.Success );
        }

        public OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id )
        {
            var result = _socialAudienceRepository.GetGenderAge( id );
            if( result.Status != OperationResultEnum.Success )
                return new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                    Enumerable.Empty<AudiencePercentage<AgeProperty>>( ), OperationResultEnum.Failed );

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.AgeRange )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<AgeProperty>
                {
                    Percentage = ( double ) x.Item2 / totalFollowers,
                    Value = new AgeProperty { Max = x.Key.Item2, Min = x.Key.Item1 }
                } ),
                OperationResultEnum.Success );
        }
    }
}