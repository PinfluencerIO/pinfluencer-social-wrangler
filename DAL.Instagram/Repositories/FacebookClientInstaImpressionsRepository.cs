using System.Collections.Generic;
using BLL.Models;
using Bootstrapping.Services.Repositories;

namespace DAL.Instagram.Repositories
{
    public class FacebookClientInstaImpressionsRepository : IInstaImpressionsRepository
    {
        public IEnumerable<InstaImpression> GetImpressions(string instaId)
        {
            throw new System.NotImplementedException();
        }
    }
}