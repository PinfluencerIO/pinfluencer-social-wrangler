namespace Bootstrapping.Services.Repositories
{
    public interface IUserRepository
    {
        OperationResult<string> GetInstagramToken(string id);
    }
}