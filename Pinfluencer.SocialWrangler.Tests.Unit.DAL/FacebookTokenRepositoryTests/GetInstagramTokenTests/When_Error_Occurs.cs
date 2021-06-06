using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookTokenRepositoryTests.GetInstagramTokenTests
{
    public class When_Error_Occurs : When_Called
    {
        private ObjectResult<string> _result;

        protected override void When( )
        {
            MockAuthServiceManagementClientDecorator
                .GetIdentityToken( Arg.Any<string>( ) )
                .Throws<AggregateException>( );

            _result = SUT.Get( Id );
        }

        [ Test ]
        public void Then_Token_Is_Empty( ) { Assert.AreEqual( "", _result.Value ); }

        [ Test ]
        public void Then_Response_Is_Fail( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}