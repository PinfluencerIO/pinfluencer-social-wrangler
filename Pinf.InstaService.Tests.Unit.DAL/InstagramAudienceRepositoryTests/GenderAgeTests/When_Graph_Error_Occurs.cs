using System.Collections.Generic;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Instagram.Dtos;
using Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GenderAgeTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Graph_Error_Occurs : When_Error_Occurs<GenderAgeProperty>
    {
        public When_Graph_Error_Occurs( FacebookApiException apiException ) : base( apiException ) { }
        
        protected override void When( )
        {
            base.When( );
            Result = Sut.GetGenderAge( "123" );
        }
        
        [ Test ]
        public void Then_Correct_Api_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<BaseRequestInsightParams>( x => x.period == "lifetime" && x.metric == "audience_gender_age" ) );
        }
    }
}