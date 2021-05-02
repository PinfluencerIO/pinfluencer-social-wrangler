using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramAudienceRepository : IInstaAudienceInsightsRepository
    {
        private readonly FacebookContext _facebookContext;

        public InstagramAudienceRepository( FacebookContext facebookContext ) { _facebookContext = facebookContext; }

        public OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry( string instaId )
        {
            throw new NotImplementedException( );
        }

        public OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId )
        {
            _facebookContext
                .FacebookClient
                .Get( $"{instaId}/insights", new RequestInsightLifetimeParams{ metric = "audience_gender_age" } );
            return new OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>(
                Enumerable.Empty<InstaFollowersInsight<GenderAgeProperty>>( ),
                OperationResultEnum.Success );
        }
    }
}