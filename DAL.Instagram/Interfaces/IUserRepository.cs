using DAL.Instagram.Models;

namespace DAL.Instagram.Interfaces
{
    public interface IUserRepository
    {
        InstaUser GetUser(string id);
    }
}