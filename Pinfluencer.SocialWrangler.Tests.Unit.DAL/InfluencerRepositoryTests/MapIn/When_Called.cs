using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InfluencerRepositoryTests.MapIn
{
    public class When_Called : Given_A_InfluencerRepository
    {
        private Influencer _result;

        protected override void When( ) { _result = SUT.MapIn( DefaultInfluencer ); }

        [ Test ]
        public void Then_Valid_Influencer_Is_Created( )
        {
            Assert.AreEqual( DefaultInfluencer.Age, _result.Age );
            Assert.AreEqual( DefaultInfluencer.Bio, _result.Bio );
            Assert.AreEqual( DefaultInfluencer.Gender, _result.Gender );
            Assert.AreEqual( DefaultInfluencer.SocialUsername, _result.Instagram );
            Assert.AreEqual( DefaultInfluencer.Location, _result.Location );
            Assert.AreEqual( DefaultInfluencer.User.Id, _result.Profile );
        }
    }
}