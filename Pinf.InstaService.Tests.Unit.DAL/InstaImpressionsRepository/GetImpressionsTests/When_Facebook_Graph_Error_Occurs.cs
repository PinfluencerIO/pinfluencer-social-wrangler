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
    public class When_Facebook_Graph_Error_Occurs : When_Called
    {
        private OperationResult<IEnumerable<InstaProfileViewsInsight>> _result;

        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws<FacebookOAuthException>( );

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