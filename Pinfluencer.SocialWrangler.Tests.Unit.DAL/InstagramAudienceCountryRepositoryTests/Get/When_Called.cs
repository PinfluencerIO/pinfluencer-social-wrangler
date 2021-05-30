using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceCountryRepositoryTests.Get
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramAudienceCountryRepository
    {
        private OperationResult<IEnumerable<AudienceCount<LocationProperty>>> _result;
        private OperationResult<IEnumerable<AudienceCount<LocationProperty>>> _operationResult;


        public When_Called( IEnumerable<AudienceCount<LocationProperty>> audienceCountries, OperationResultEnum operationResultEnum )
        {
            _operationResult =
                new OperationResult<IEnumerable<AudienceCount<LocationProperty>>>( audienceCountries,
                    operationResultEnum );
        }

        private static readonly object [ ] data = {
            new object[]
            {
                new []
                {
                    new AudienceCount<LocationProperty>
                    {
                        Count = 6,
                        Property = new LocationProperty
                        {
                            City = "London",
                            Country = "United Kingdom",
                            CountryCode = CountryEnum.GB
                        }
                    },
                    new AudienceCount<LocationProperty>
                    {
                        Count = 6,
                        Property = new LocationProperty
                        {
                            City = "New York",
                            Country = "United States",
                            CountryCode = CountryEnum.US
                        }
                    },
                    new AudienceCount<LocationProperty>
                    {
                        Count = 6,
                        Property = new LocationProperty
                        {
                            City = "Barcelona",
                            Country = "Spain",
                            CountryCode = CountryEnum.ES
                        }
                    }
                },
                OperationResultEnum.Success
            },
            new object[]
            {
                Enumerable.Empty<AudienceCount<LocationProperty>>( ),
                OperationResultEnum.Failed
            }
        };

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<object>>, IEnumerable<AudienceCount<LocationProperty>>>>( ),
                    Arg.Any<IEnumerable<AudienceCount<LocationProperty>>>( ),
                    Arg.Any<RequestInsightParams>( ) )
                .Returns( _operationResult );
            _result = SUT.Get( "123" );
        }
        
        [ Test ] public void Then_Get_Users_Is_Called_Once( ) =>
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<Metric<object>>, IEnumerable<AudienceCount<LocationProperty>>>>( ),
                    Arg.Any<IEnumerable<AudienceCount<LocationProperty>>>( ),
                    Arg.Any<RequestInsightParams>( ) );

        [ Test ]
        public void Then_Valid_Call_Was_Made( ) =>
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<AudienceCount<LocationProperty>>, DataArray<Metric<object>>>( "123/insights",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<AudienceCount<LocationProperty>>>( x => !x.Any( ) ),
                    Arg.Is<RequestInsightParams>( x => x.metric == "audience_country" && x.period == "lifetime" ) );

        [ Test ] public void Then_Valid_Response_Was_Returned( )
        {
            Assert.AreSame( _operationResult, _result );
        }
    }
}