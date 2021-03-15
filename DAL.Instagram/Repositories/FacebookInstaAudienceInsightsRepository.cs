using System.Collections.Generic;
using BLL.Models.Insights;
using Bootstrapping.Services;
using Bootstrapping.Services.Repositories;

namespace DAL.Instagram.Repositories
{
    public class FacebookInstaAudienceInsightsRepository : IInstaAudienceInsightsRepository
    {
        private FacebookContext _facebookContext;

        public FacebookInstaAudienceInsightsRepository(FacebookContext facebookContext)
        {
            _facebookContext = facebookContext;
        }
        
        public OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry(string instaId)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge(string instaId)
        {
            throw new System.NotImplementedException();
        }
    }
}