using System;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Instagram.Dtos;
using Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    public class When_Retrieved_Successfully : When_Called
    {
        private OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> _result;

        protected override void When( )
        {
            MockFacebookClient
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Returns( new
                {
                    data = new dynamic [ ]
                    {
                        new
                        {
                            name = "audience_country",
                            period = "lifetime",
                            values = new dynamic [ ]
                            {
                                new
                                {
                                    value = new
                                    {
                                        EG = 1,
                                        SG = 1,
                                        AU = 1,
                                        IN = 1,
                                        CI = 1,
                                        PH = 1,
                                        GB = 113,
                                        ES = 1,
                                        US = 11
                                    },
                                    end_time = "2020-12-19T08:00:00+0000"
                                }
                            },
                            title = "Audience country",
                            description = "The countries of this profile's followers",
                            id = "17841405594881885/insights/audience_country/lifetime"
                        }
                    }
                } );
            _result = Sut.GetCountry( "123" );
        }

        [ Test ]
        public void Then_Success_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
        
        [ Test ]
        public void Then_Correct_Min_Age_Ranges_Were_Returned( )
        {
            var countries = new [ ]
            {
                "Egypt",
                "Singapore",
                "Australia",
                "India",
                "Côte d’Ivoire",
                "Philippines",
                "United Kingdom",
                "Spain",
                "United States"
            };
            Assert.True( _result.Value.Select( x => x.Property.Country.EnglishName ).SequenceEqual( countries ) );
        }
        
        [ Test ]
        public void Then_Correct_Follower_Counts_Were_Returned( )
        {
            var followerCounts = new [ ]
            {
                1,
                1,
                1,
                1,
                1,
                1,
                113,
                1,
                11
            };
            Assert.True( _result.Value.Select( x => x.Count ).SequenceEqual( followerCounts ) );
        }

        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}