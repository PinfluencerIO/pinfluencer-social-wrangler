using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialContentFacadeTests.GetEngagementRate
{
    public class When_No_Content_Has_Been_Posted_In_Last_28_Days : When_Called
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
                            TimeOfUpload = new DateTime( 2021, 4, 23 )
                        },
                        new Content
                        {
                            Id = "54354",
                            TimeOfUpload = new DateTime( 2021, 4, 10 )
                        },
                        new Content
                        {
                            Id = "7876",
                            TimeOfUpload = new DateTime( 2021, 4, 7 )
                        }
                    }
                } );
            _result = SUT.GetEngagementRate( );
        }

        [ Test ]
        public void Then_Correct_Engagement_Rate_Was_Calculated( )
        {
            Assert.AreEqual( 0, _result.Value );
        }
    }
}