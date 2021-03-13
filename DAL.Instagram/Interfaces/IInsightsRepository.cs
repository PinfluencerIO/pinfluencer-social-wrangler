using DAL.Instagram.Models;

namespace DAL.Instagram.Interfaces
{
    public interface IInsightsRepository
    {
        Metric GetImpressions(string instaId);
    }
}