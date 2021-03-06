using System;
using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceCountryRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramAudienceCountryRepository
    {
        private ObjectResult<IEnumerable<AudienceCount<CountryProperty>>> _result;
        private readonly ObjectResult<IEnumerable<AudienceCount<CountryProperty>>> _objectResult;


        public When_Called( IEnumerable<AudienceCount<CountryProperty>> audienceCountries,
            OperationResultEnum operationResultEnum )
        {
            _objectResult =
                new ObjectResult<IEnumerable<AudienceCount<CountryProperty>>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data =
        {
            new object [ ]
            {
                new [ ]
                {
                    new AudienceCount<CountryProperty>
                    {
                        Count = 6,
                        Property = new CountryProperty
                        {
                            Country = "United Kingdom",
                            CountryCode = CountryEnum.GB
                        }
                    },
                    new AudienceCount<CountryProperty>
                    {
                        Count = 6,
                        Property = new CountryProperty
                        {
                            Country = "United States",
                            CountryCode = CountryEnum.US
                        }
                    },
                    new AudienceCount<CountryProperty>
                    {
                        Count = 6,
                        Property = new CountryProperty
                        {
                            Country = "Spain",
                            CountryCode = CountryEnum.ES
                        }
                    }
                },
                OperationResultEnum.Success
            },
            new object [ ]
            {
                Enumerable.Empty<AudienceCount<CountryProperty>>( ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<object>>, IEnumerable<AudienceCount<CountryProperty>>>>( ),
                    Arg.Any<IEnumerable<AudienceCount<CountryProperty>>>( ),
                    Arg.Any<BaseRequestInsightParams>( ) )
                .Returns( _objectResult );
            _result = SUT.Get( "123" );
        }

        [ Test ]
        public void Then_Get_Audience_Country_Is_Called_Once( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<object>>, IEnumerable<AudienceCount<CountryProperty>>>>( ),
                    Arg.Any<IEnumerable<AudienceCount<CountryProperty>>>( ),
                    Arg.Any<BaseRequestInsightParams>( ) );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<AudienceCount<CountryProperty>>, DataArray<Metric<object>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<AudienceCount<CountryProperty>>>( x => !x.Any( ) ),
                    Arg.Is<BaseRequestInsightParams>( x => x.metric == "audience_country" && x.period == "lifetime" ) );
        }

        [ Test ]
        public void Then_Valid_Response_Was_Returned( ) { Assert.AreSame( _objectResult, _result ); }
    }
}