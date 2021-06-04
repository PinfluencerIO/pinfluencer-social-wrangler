using System.Collections;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Pinfluencer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class InfluencerRepository :
        IDataMappableIn<InfluencerModel,
            Influencer>,
        IInfluencerRepository
    {
        private IBubbleDataHandler<InfluencerRepository> _bubbleDataHandler;
        public InfluencerRepository( IBubbleDataHandler<InfluencerRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResultEnum Create( InfluencerModel influencer ) =>
            _bubbleDataHandler.Create( "influencer", influencer, MapIn );

        public Influencer MapIn( InfluencerModel model ) =>
            new Influencer
            {
                Age = model.Age,
                Bio = model.Bio,
                Gender = model.Gender,
                Instagram = model.SocialUsername,
                Location = model.Location,
                Profile = model.User.Id
            };
    }
}