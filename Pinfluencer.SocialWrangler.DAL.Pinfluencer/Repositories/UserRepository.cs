
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    //TODO: REFACTOR SEPERATE DATA SOURCES INTO SEPERATE REPOSITORIES
    //TODO: ADD LOGGING !!!

    public class UserRepository :
        IUserRepository,
        IDataMappableOut<User,
            TypeResponse<Profile>>
    {
        private readonly IBubbleDataHandler<UserRepository> _bubbleDataHandler;

        public UserRepository( IBubbleDataHandler<UserRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<User> Get( string id ) =>
            _bubbleDataHandler.Read<User,TypeResponse<Profile>>( $"profile/{id}",
                MapOut,
                new User() );

        public User MapOut( TypeResponse<Profile> dto ) =>
            new User { Id = dto.Type.Id, Name = dto.Type.Name };
    }
}