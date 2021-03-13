using System.Collections.Generic;
using BLL.InstagramFetcher.Models;
using DAL.Instagram.Interfaces;

namespace DAL.Instagram.Repositories
{
    public class HttpInsightsRepository : IInsightsRepository
    {
        public IEnumerable<Impression> GetImpressions(string instaId)
        {
            throw new System.NotImplementedException();
        }
    }
}