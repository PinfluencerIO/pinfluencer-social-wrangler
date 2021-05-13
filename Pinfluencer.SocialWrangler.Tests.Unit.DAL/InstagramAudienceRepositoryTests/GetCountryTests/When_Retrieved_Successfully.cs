﻿using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Instagram.Dtos;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    public class When_Retrieved_Successfully : When_Successful<LocationProperty>
    {
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
            Result = Sut.GetCountry( "123" );
        }

        [ Test ]
        public void Then_Correct_Countries_Were_Returned( )
        {
            var countries = new [ ]
            {
                "Egypt",
                "Singapore",
                "Australia",
                "India",
                "Côte d'Ivoire",
                "Philippines",
                "United Kingdom",
                "Spain",
                "United States"
            };
            Assert.True( Result.Value.Select( x => x.Property.Country ).SequenceEqual( countries ) );
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
            Assert.True( Result.Value.Select( x => x.Count ).SequenceEqual( followerCounts ) );
        }

        [ Test ]
        public void Then_Correct_Api_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<BaseRequestInsightParams>( x => x.period == "lifetime" && x.metric == "audience_country" ) );
        }
    }
}