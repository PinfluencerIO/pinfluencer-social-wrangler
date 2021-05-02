using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests.Shared
{
    public abstract class When_Called : Given_A_InstagramAudienceRepository
    {
        [ Test ]
        public void Then_Graph_Api_Was_Called_Once( )
        {
            MockFacebookClient
                .Received( 1 )
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Api_Endpoint_Was_Called( )
        {
            MockFacebookClient
                .Received( )
                .Get( "123/insights", Arg.Any<object>( ) );
        }
        
                
        [ Test ]
        public void Then_Correct_Api_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<RequestInsightLifetimeParams>( x => x.period == "lifetime" && x.metric == "audience_country" ) );
        }
    }
}