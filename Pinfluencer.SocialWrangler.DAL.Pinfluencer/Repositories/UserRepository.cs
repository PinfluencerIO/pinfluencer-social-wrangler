using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;
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

        public User MapOut( TypeResponse<Profile> dto ) { return new User { Id = dto.Type.Id, Name = dto.Type.Name }; }

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<User> Get( string id )
        {
            return _bubbleDataHandler.Read<User, TypeResponse<Profile>>( $"profile/{id}",
                MapOut,
                new User( ) );
        }
    }
}