using System.Collections.Generic;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Graph_Error_Occurs : Given_A_InstagramAudienceRepository
    {
        private readonly FacebookApiException _apiException;
        private OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> _result;

        public When_Graph_Error_Occurs( FacebookApiException apiException ) { _apiException = apiException; }
        
        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( _apiException );
            _result = Sut.GetGenderAge( "123" );
        }

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
                .Get( Arg.Any<string>( ), Arg.Is<RequestInsightLifetimeParams>( x => x.period == "lifetime" && x.metric == "audience_gender_age" ) );
        }
        
        [ Test ]
        public void Then_Success_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
    }
}