using System.Collections.Generic;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Instagram.Dtos;
using Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Graph_Error_Occurs : When_Called
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
        public void Then_Success_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Failed, _result.Status );
        }
    }
}