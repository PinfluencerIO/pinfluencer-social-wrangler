using System.Collections;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    public class InfluencerRepository :
        IDataMappable<InfluencerModel,
            Influencer,
            IEnumerable<InfluencerModel>,
            TypeResponse<BubbleCollection<Influencer>>>, IInfluencerRepository
    {
        private IBubbleDataHandler<InfluencerRepository> _bubbleDataHandler;
        public InfluencerRepository( IBubbleDataHandler<InfluencerRepository> bubbleDataHandler )
        {
            _bubbleDataHandler = bubbleDataHandler;
        }

        public OperationResultEnum Create( InfluencerModel influencer ) =>
            _bubbleDataHandler.Create( "influencer", influencer, MapIn );

        public InfluencerModel MapOut( Influencer dto ) { throw new System.NotImplementedException( ); }

        public Influencer MapIn( InfluencerModel model ) =>
            new Influencer
            {
                Age = model.Age,
                Bio = model.Bio,
                Gender = model.Gender,
                Instagram = model.InstagramHandle,
                Location = model.Location,
                Profile = model.User.Id
            };

        public IEnumerable<InfluencerModel> MapMany( TypeResponse<BubbleCollection<Influencer>> dtoCollection ) { throw new System.NotImplementedException( ); }
    }
}