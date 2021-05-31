using System;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookUserRepositoryTests
{
    public class Given_A_FacebookUserRepository : DataGivenWhenThen<FacebookUserRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new FacebookUserRepository( MockFacebookDataHandler, MockDateTime );
        }
    }
}