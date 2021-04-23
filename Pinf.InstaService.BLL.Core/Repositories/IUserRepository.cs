namespace Pinf.InstaService.BLL.Core.Repositories
{
    public interface IUserRepository
    {
        OperationResult<string> GetInstagramToken(string id);
    }
}