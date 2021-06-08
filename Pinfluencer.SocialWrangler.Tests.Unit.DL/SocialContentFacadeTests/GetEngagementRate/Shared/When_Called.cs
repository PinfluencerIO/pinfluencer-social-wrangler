using System;
using System.Collections.Generic;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate.Shared
{
    public abstract class When_Called : Given_A_SocialContentFacade
    {
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
            MockSocialInsightsUserFacade
                .GetUsers( )
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
        }
    }
}