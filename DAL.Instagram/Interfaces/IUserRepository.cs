
using BLL.InstagramFetcher.Models;

namespace DAL.Instagram.Interfaces
{
    public interface IUserRepository
    {
        InstaUser GetUser(string id);
    }
}