using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.User;

namespace Pinf.InstaService.BLL.Facades
{
    public class InfluencerFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IInstaUserRepository _instaUserRepository;

        public InfluencerFacade( IUserRepository userRepository, IInstaUserRepository instaUserRepository )
        {
            _userRepository = userRepository;
            _instaUserRepository = instaUserRepository;
        }
        
        public OperationResultEnum OnboardInfluencer( string id )
        {
            var user = _userRepository.Get( id ).Value;
            var instaUser = _instaUserRepository.GetAll(  ).Value.First();
            _userRepository.CreateInfluencer( new Influencer
            {
                Age = user.Age,
                Bio = instaUser.Bio,
                Gender = user.Gender,
                InstagramHandle = instaUser.Handle,
                Location = user.Location,
                User = user
            } );
            return OperationResultEnum.Success;
        }
    }
}