using System.Linq;
using Pinf.InstaService.BLL.Models.InstaUser;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Repositories;

namespace Pinf.InstaService.BLL.InstagramFetcher.Services
{
    public class InstaUserService
    {
        private readonly IInstaUserRepository _instaUserRepository;

        public InstaUserService(IInstaUserRepository instaUserRepository)
        {
            _instaUserRepository = instaUserRepository;
        }

        public OperationResult<InstaUserIdentityCollection> GetAll()
        {
            var users = _instaUserRepository.GetUsers();

            return new OperationResult<InstaUserIdentityCollection>(
                new InstaUserIdentityCollection(
                    users.Value.Select(x => x.Identity),
                    users.Value.Count() > 1,
                    !users.Value.Any()
                ),
                users.Status
            );
        }
    }
}