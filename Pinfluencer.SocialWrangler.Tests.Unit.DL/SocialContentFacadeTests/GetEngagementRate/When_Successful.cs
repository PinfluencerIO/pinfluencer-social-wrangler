using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate
{
    public class When_Successful : When_Called
    {
        private ObjectResult<double> _result;

        protected override void When( )
        {
            base.When( );
            _result = SUT.GetEngagementRate( );
        }

        [ Test ]
        public void Then_Correct_Content_Was_Fetched( )
        {
            MockSocialContentRepository
                .Received( 1 )
                .GetAll( Arg.Any<string>( ) );
            MockSocialContentRepository
                .Received( )
                .GetAll( "14354432" );
        }
        
        [ Test ]
        public void Then_Correct_Content_Engagement_Was_Fetched( )
        {
            MockSocialEngagementRepository
                .Received( 2 )
                .Get( Arg.Any<string>( ) );
            MockSocialEngagementRepository
                .Received( )
                .Get( "12343" );
            MockSocialEngagementRepository
                .Received( )
                .Get( "54354" );
        }

        [ Test ]
        public void Then_Correct_Engagement_Rate_Was_Calculated( )
        {
            Assert.AreEqual( 0.0829, _result.Value );
        }

        [ Test ]
        public void Then_Success_Status_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
    }
}