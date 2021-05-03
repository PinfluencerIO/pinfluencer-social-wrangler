﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Core.Models.InstaUser;

namespace Pinf.InstaService.BLL.Facades
{
    public class InstagramFacade
    {
        private readonly IInstaImpressionsRepository _impressionsRepository;
        private readonly IInstaUserRepository _instaUserRepository;
        private readonly IInstaAudienceInsightsRepository _instaAudienceInsightsRepository;

        public InstagramFacade(
            IInstaImpressionsRepository impressionsRepository, IInstaUserRepository instaUserRepository, IInstaAudienceInsightsRepository instaAudienceInsightsRepository )
        {
            _impressionsRepository = impressionsRepository;
            _instaUserRepository = instaUserRepository;
            _instaAudienceInsightsRepository = instaAudienceInsightsRepository;
        }

        public OperationResult<IEnumerable<ProfileViewsInsight>> GetMonthlyProfileViews( string id ) => _impressionsRepository.GetImpressions( id );

        //TODO: MOVE BUSINESS RULES OUT OF DATA LAYER ( NUMBER OF USERS RETURNED SHOULDN'T CONCERN DATA LAYER )
        public OperationResult<IEnumerable<InstaUser>> GetUsers( ) => _instaUserRepository.GetAll( );

        public OperationResult<IEnumerable<AudiencePercentage<RegionInfo>>> GetAudienceCountryInsights( string id )
        {
            var result = _instaAudienceInsightsRepository.GetCountry( id );
            if( result.Status != OperationResultEnum.Success )
            {
                return new OperationResult<IEnumerable<AudiencePercentage<RegionInfo>>>(
                    Enumerable.Empty<AudiencePercentage<RegionInfo>>( ), OperationResultEnum.Failed );
            }

            var totalFollowers = result.Value.Sum( x => x.Count );
            return new OperationResult<IEnumerable<AudiencePercentage<RegionInfo>>>(
                result.Value.Select( x => new AudiencePercentage<RegionInfo>
                    { Percentage = ( double )x.Count / ( double )totalFollowers, Value = x.Property } ),
                OperationResultEnum.Success );
        }

        public OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id )
        {
            var result = _instaAudienceInsightsRepository.GetGenderAge( id );
            if( result.Status != OperationResultEnum.Success )
            {
                return new OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                    Enumerable.Empty<AudiencePercentage<GenderEnum>>( ), OperationResultEnum.Failed );
            }

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.Gender )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<GenderEnum>{ Percentage =  ( double )x.Item2/totalFollowers, Value = x.Key } ),
                OperationResultEnum.Success );
        }
        
        public OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id )
        {
            var result = _instaAudienceInsightsRepository.GetGenderAge( id );
            if( result.Status != OperationResultEnum.Success )
            {
                return new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                    Enumerable.Empty<AudiencePercentage<AgeProperty>>( ), OperationResultEnum.Failed );
            }

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.AgeRange )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<AgeProperty>{ Percentage =  ( double )x.Item2/totalFollowers, Value = new AgeProperty{ AgeRange = x.Key } } ),
                OperationResultEnum.Success );
        }
    }
}