using System;
using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate
{
    public class When_Post_Was_Posted_Exactly_28_Days_Ago : When_Called
    {
        private ObjectResult<double> _result;

        protected override void When( )
        {
            base.When( );
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
                            TimeOfUpload = new DateTime( 2021, 4, 23 )
                        }
                    }
                } );
            _result = SUT.GetEngagementRate( );
        }

        [ Test ]
        public void Then_Correct_Engagement_Rate_Was_Calculated( )
        {
            Assert.AreEqual( 0.0829, _result.Value );
        }
    }
}