using System;
using System.Collections.Generic;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;

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
            throw new NotImplementedException( );
        }
    }
}