using System.Collections.Generic;
using BLL.Models;

namespace Bootstrapping.Services.Repositories
{
    public interface IInstaAudienceInsightsRepository
    {
        IEnumerable<InstaFollowersInsight<CountryProperty>> GetCountry(string instaId);
        
        IEnumerable<InstaFollowersInsight<GenderAgeProperty>> GetGenderAge(string instaId);
    }
}