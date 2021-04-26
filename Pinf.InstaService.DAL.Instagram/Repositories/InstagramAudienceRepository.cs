using System.Collections.Generic;
using Pinf.InstaService.BLL.Models.Insights;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Interfaces.Repositories;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramAudienceRepository : IInstaAudienceInsightsRepository
    {
        private readonly FacebookContext _facebookContext;
        public InstagramAudienceRepository( FacebookContext facebookContext )
        {
            _facebookContext = facebookContext;
        }

        public OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry( string instaId ) { throw new System.NotImplementedException( ); }

        public OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId ) { throw new System.NotImplementedException( ); }
    }
}