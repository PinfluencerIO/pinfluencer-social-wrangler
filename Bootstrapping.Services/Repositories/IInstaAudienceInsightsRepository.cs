using System.Collections.Generic;
using BLL.Models;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        QueryResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry(string instaId);
        
        QueryResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge(string instaId);
    }
}