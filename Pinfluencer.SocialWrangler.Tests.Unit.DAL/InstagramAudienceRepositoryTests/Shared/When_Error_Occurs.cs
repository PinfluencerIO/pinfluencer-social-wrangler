using Facebook;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared
{
    public abstract class When_Error_Occurs<T> : When_Any_Called<T>
    {
        protected readonly FacebookApiException ApiException;

        protected When_Error_Occurs( FacebookApiException apiException ) { ApiException = apiException; }

        protected override void When( )
        {
            MockFacebookDecorator
                .Get<DataArray<Metric<object>>>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Throws( ApiException );
        }

        [ Test ]
        public void Then_Failiure_Was_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result.Status ); }

        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}