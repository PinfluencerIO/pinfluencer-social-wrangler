namespace Bootstrapping.Services.Repositories
{
    public interface IUserRepository
    {
        QueryResult<string> GetInstagramToken(string id);
    }
}