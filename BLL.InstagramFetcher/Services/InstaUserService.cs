using System;
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
            return new OperationResult<InstaUserIdentityCollection>(
                new InstaUserIdentityCollection(
                    new[] {new InstaUserIdentity("example", "123213")},
                    false,
                    false
                ),
                OperationResultEnum.Failed
            );
        }
    }
}