using System;
using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceGenderAgeRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramGenderAgeRepository
    {
        private ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>> _result;
        private readonly ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>> _objectResult;


        public When_Called( IEnumerable<AudienceCount<GenderAgeProperty>> audienceCountries,
            OperationResultEnum operationResultEnum )
        {
            _objectResult =
                new ObjectResult<IEnumerable<AudienceCount<GenderAgeProperty>>>( audienceCountries,
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
                    Arg.Any<BaseRequestInsightParams>( ) )
                .Returns( _objectResult );
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
                    Arg.Any<BaseRequestInsightParams>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<AudienceCount<GenderAgeProperty>>, DataArray<Metric<object>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<AudienceCount<GenderAgeProperty>>>( x => !x.Any( ) ),
                    Arg.Is<BaseRequestInsightParams>( x => x.metric == "audience_gender_age" && x.period == "lifetime" ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}