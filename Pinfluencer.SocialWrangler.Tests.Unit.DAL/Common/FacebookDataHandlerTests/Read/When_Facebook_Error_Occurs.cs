using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests.Read
{
    [ TestFixtureSource( nameof( FacebookExceptionFixture ) ) ]
    public class When_Facebook_Error_Occurs : Given_A_FacebookDataHandler
    {
        private readonly FacebookApiException _facebookApiException;
        private ObjectResult<Model> _result;

        public When_Facebook_Error_Occurs( FacebookApiException facebookApiException )
        {
            _facebookApiException = facebookApiException;
        }

        protected override void When( )
        {
            MockFacebookDecorator
                .Get<Dto>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( _facebookApiException );
            _result = FacebookSut.Read<Model, Dto>( "example", MapOut, new Model( ) );
        }

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, _result.Status ); }

        [ Test ]
        public void Then_Error_Was_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}