using System;
using System.Linq;
using BLL.Models.InstaUser;
using Bootstrapping.Services;
using Bootstrapping.Services.Enum;
using Bootstrapping.Services.Repositories;

namespace BLL.InstagramFetcher.Services
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
                    users.Value.Count()>1,
                    !users.Value.Any()
                ),
                users.Status
            );
        }
    }
}