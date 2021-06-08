using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate
{
    public class When_Successful : Given_A_SocialContentFacade
    {
        private ObjectResult<double> _result;

        protected override void When( )
        {
            CurrentTime = new DateTime( 2021, 5, 21 );
            MockSocialContentRepository
                .GetAll( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<Content>>
                {
                    Status = OperationResultEnum.Success,
                    Value = new [ ]
                    {
                        new Content
                        {
                            Id = "12343",
                            TimeOfUpload = new DateTime( 2021, 5, 10 )
                        },
                        new Content
                        {
                            Id = "54354",
                            TimeOfUpload = new DateTime( 2021, 5, 7 )
                        },
                        new Content
                        {
                            Id = "7876",
                            TimeOfUpload = new DateTime( 2021, 4, 1 )
                        }
                    }
                } );
            MockSocialEngagementRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new ObjectResult<int>
                    {
                        Status = OperationResultEnum.Success,
                        Value = 27
                    },
                    new ObjectResult<int>
                    {
                        Status = OperationResultEnum.Success,
                        Value = 45
                    } );
            MockSocialInsightsUserRepository
                .GetAll( )
                .Returns( new ObjectResult<IEnumerable<SocialInsightsUser>>
                {
                    Status = OperationResultEnum.Success,
                    Value = new [ ]
                    {
                        new SocialInsightsUser
                        {
                            Bio = "u958hushfiuijds",
                            Id = "14354432",
                            Followers = 434,
                            Name = "fkdwar",
                            Username = "434tgkijfgfd"
                        }
                    }
                } );
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
            Assert.AreEqual( 0.091, _result.Value );
        }

        [ Test ]
        public void Then_Success_Status_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
    }
}