using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class InfluencerRepository :
        IDataMappableIn<InfluencerModel,
            Influencer>,
        IInfluencerRepository
    {
        private readonly IBubbleDataHandler<InfluencerRepository> _bubbleDataHandler;

        public InfluencerRepository( IBubbleDataHandler<InfluencerRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public Influencer MapIn( InfluencerModel model )
        {
            return new Influencer
            {
                Age = model.Age,
                Bio = model.Bio,
                Gender = model.Gender,
                Instagram = model.SocialUsername,
                Location = model.Location,
                Profile = model.User.Id
            };
        }

        public OperationResultEnum Create( InfluencerModel influencer )
        {
            return _bubbleDataHandler.Create( "influencer", influencer, MapIn );
        }
    }
}