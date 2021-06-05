using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceGenderAgeRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramGenderAgeRepository
    {
        private OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> _result;
        private readonly OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> _operationResult;


        public When_Called( IEnumerable<AudienceCount<GenderAgeProperty>> audienceCountries,
            OperationResultEnum operationResultEnum )
        {
            _operationResult =
                new OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                new [ ]
                {
                    new AudienceCount<GenderAgeProperty>
                    {
                        Count = 6,
                        Property = new GenderAgeProperty
                        {
                            Gender = GenderEnum.Male,
                            AgeRange = new Tuple<int, int?>( 24, 35 )
                        }
                    },
                    new AudienceCount<GenderAgeProperty>
                    {
                        Count = 54,
                        Property = new GenderAgeProperty
                        {
                            Gender = GenderEnum.Female,
                            AgeRange = new Tuple<int, int?>( 24, 35 )
                        }
                    },
                    new AudienceCount<GenderAgeProperty>
                    {
                        Count = 65,
                        Property = new GenderAgeProperty
                        {
                            Gender = GenderEnum.Male,
                            AgeRange = new Tuple<int, int?>( 36, 45 )
                        }
                    }
                },
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<AudienceCount<GenderAgeProperty>>( ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<object>>, IEnumerable<AudienceCount<GenderAgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudienceCount<GenderAgeProperty>>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( _operationResult );
            _result = SUT.Get( "123" );
        }

        [ Test ]
        public void Then_Get_Audience_Gender_Age_Is_Called_Once( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<object>>, IEnumerable<AudienceCount<GenderAgeProperty>>>>( ),
                    Arg.Any<IEnumerable<AudienceCount<GenderAgeProperty>>>( ),
                    Arg.Any<RequestInsightParams>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<AudienceCount<GenderAgeProperty>>, DataArray<Metric<object>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<AudienceCount<GenderAgeProperty>>>( x => !x.Any( ) ),
                    Arg.Is<RequestInsightParams>( x => x.metric == "audience_gender_age" && x.period == "lifetime" ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _operationResult, _result ); }
    }
}