using Facebook;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Instagram.Dtos;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Graph_Error_Occurs : When_Error_Occurs<LocationProperty>
    {
        public When_Graph_Error_Occurs( FacebookApiException apiException ) : base( apiException )
        {
        }
        
        protected override void When( )
        {
            base.When( );
            Result = Sut.GetCountry( "123" );
        }
        
        [ Test ]
        public void Then_Correct_Api_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<BaseRequestInsightParams>( x => x.period == "lifetime" && x.metric == "audience_country" ) );
        }
    }
}