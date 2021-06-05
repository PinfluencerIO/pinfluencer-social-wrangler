using System.Collections.Generic;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Facebook_Graph_Error_Occurs : When_Called
    {
        private readonly FacebookApiException _apiException;
        private OperationResult<IEnumerable<ContentImpressions>> _result;

        public When_Facebook_Graph_Error_Occurs( FacebookApiException apiException ) { _apiException = apiException; }

        protected override void When( )
        {
            MockFacebookDecorator
                .Get<DataArray<Metric<int>>>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( _apiException );

            base.When( );

            _result = SUT.Get( TestId );
        }

        [ Test ]
        public void Then_The_Response_Is_Empty( ) { Assert.IsEmpty( _result.Value ); }

        [ Test ]
        public void Then_The_Status_Is_Fail( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}