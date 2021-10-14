using System.Collections.Generic;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial.Shared
{
    public class When_Called : Given_An_AudienceFacade
    {
        protected override void When( )
        {
            MockSocialAudienceFacade
                .GetAudienceAgeInsights( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>
                {
                    Status = OperationResultEnum.Success,
                    Value = new [ ]
                    {
                        new AudiencePercentage<AgeProperty>
                        {
                            Percentage = 0.2,
                            Value = new AgeProperty
                            {
                                Min = 18,
                                Max = 24
                            }
                        },
                        new AudiencePercentage<AgeProperty>
                        {
                            Percentage = 0.8,
                            Value = new AgeProperty
                            {
                                Min = 25,
                                Max = 36
                            }
                        }
                    }
                } );
            MockSocialAudienceFacade
                .GetAudienceCountryInsights( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>>
                {
                    Status = OperationResultEnum.Success,
                    Value = new [ ]
                    {
                        new AudiencePercentage<CountryProperty>
                        {
                            Percentage = 0.2,
                            Value = new CountryProperty
                            {
                                Country = "United Kingdom",
                                CountryCode = CountryEnum.GB
                            }
                        },
                        new AudiencePercentage<CountryProperty>
                        {
                            Percentage = 0.8,
                            Value = new CountryProperty
                            {
                                Country = "United States",
                                CountryCode = CountryEnum.US
                            }
                        }
                    }
                } );
            MockSocialAudienceFacade
                .GetAudienceGenderInsights( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>>
                {
                    Status = OperationResultEnum.Success,
                    Value = new [ ]
                    {
                        new AudiencePercentage<GenderEnum>
                        {
                            Percentage = 0.4,
                            Value = GenderEnum.Male
                        },
                        new AudiencePercentage<GenderEnum>
                        {
                            Percentage = 0.6,
                            Value = GenderEnum.Female
                        }
                    }
                } );
            MockSocialInsightsUserFacade
                .GetFirstUser( )
                .Returns( new ObjectResult<SocialInsightsUser>
                {
                    Status = OperationResultEnum.Success,
                    Value = 
                        new SocialInsightsUser
                        {
                            Id = When_Successful.TestUserId
                        }
                } );
            MockSocialContentFacade
                .GetEngagementRate( )
                .Returns( new ObjectResult<double>
                {
                    Status = OperationResultEnum.Success,
                    Value = 0.8
                } );
            MockSocialContentFacade
                .GetReach( Arg.Any<string>( ) )
                .Returns( new ObjectResult<int>
                {
                    Status = OperationResultEnum.Success,
                    Value = 25
                } );
            MockSocialContentFacade
                .GetImpressions( Arg.Any<string>( ) )
                .Returns( new ObjectResult<int>
                {
                    Status = OperationResultEnum.Success,
                    Value = 123
                } );
        }
    }
}