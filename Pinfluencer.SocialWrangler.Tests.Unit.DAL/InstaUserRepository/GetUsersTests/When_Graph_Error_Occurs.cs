﻿using System.Collections.Generic;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaUserRepository.GetUsersTests
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Graph_Error_Occurs : When_Get_Users_Is_Called
    {
        private OperationResult<IEnumerable<SocialInsightsUser>> _result;
        private readonly FacebookApiException _apiException;
        public When_Graph_Error_Occurs( FacebookApiException apiException ) { _apiException = apiException; }

        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( _apiException );

            _result = Sut.GetAll( );
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