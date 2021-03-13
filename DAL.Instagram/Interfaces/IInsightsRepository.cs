using System.Collections.Generic;
using BLL.InstagramFetcher.Models;

namespace DAL.Instagram.Interfaces
{
    public interface IInsightsRepository
    {
        IEnumerable<Impression> GetImpressions(string instaId);
    }
}