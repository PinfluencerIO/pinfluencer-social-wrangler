using Aidan.Common.Core;
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

    public class BubbleUserRepository :
        IUserRepository,
        IDataMappableOut<User,
            TypeResponse<Profile>>
    {
        private readonly IBubbleDataHandler<BubbleUserRepository> _bubbleDataHandler;

        public BubbleUserRepository( IBubbleDataHandler<BubbleUserRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public User MapOut( TypeResponse<Profile> dto ) { return new User { Id = dto.Type.Id, Name = dto.Type.Name }; }

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public ObjectResult<User> Get( string id )
        {
            return _bubbleDataHandler.Read<User, TypeResponse<Profile>>( $"profile/{id}",
                MapOut,
                new User( ) );
        }
    }
}