using System;
using System.Collections.Generic;
using Facebook;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Facebook_Graph_Error_Occurs : When_Called
    {
        private readonly FacebookApiException _apiException;
        private OperationResult<IEnumerable<InstaProfileViewsInsight>> _result;

        public When_Facebook_Graph_Error_Occurs( FacebookApiException apiException )
        {
            _apiException = apiException;
        }
        
        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( _apiException );

            base.When( );

            _result = Sut.GetImpressions( TestId );
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