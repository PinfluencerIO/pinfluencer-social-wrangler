using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GenderAgeTests
{
    public class When_Retrieved_Successfully : When_Successful<GenderAgeProperty>
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
                            name = "audience_gender_age",
                            period = "lifetime",
                            values = new dynamic [ ]
                            {
                                new
                                {
                                    value = new Dictionary<string, int>
                                    {
                                        { "F.18-24", 39 },
                                        { "F.25-34", 4 },
                                        { "F.45-54", 1 },
                                        { "M.18-24", 73 },
                                        { "M.25-34", 9 },
                                        { "M.35-44", 2 },
                                        { "M.45-54", 2 },
                                        { "M.55-64", 1 },
                                        { "M.65+", 1 }
                                    },
                                    end_time = "2020-12-19T08:00:00+0000"
                                }
                            },
                            title = "Gender and age",
                            description = "The gender and age distribution of this profile's followers",
                            id = "17841405594881885/insights/audience_gender_age/lifetime"
                        }
                    }
                } );
            Result = SUT.GetGenderAge( "123" );
        }

        [ Test ]
        public void Then_Correct_Min_Age_Ranges_Were_Returned( )
        {
            var minAges = new [ ] { 18, 25, 45, 18, 25, 35, 45, 55, 65 }
                .OrderBy( x => x );
            Assert.True( Result.Value
                .Select( x => x.Property.AgeRange.Item1 )
                .OrderBy( x => x )
                .SequenceEqual( minAges ) );
        }
        
        [ Test ]
        public void Then_Correct_Max_Age_Ranges_Were_Returned( )
        {
            var maxAges = new int?[ ] { 24, 34, 54, 24, 34, 44, 54, 64, null }
                .OrderBy( x => x );
            Assert.True( Result.Value
                .Select( x => x.Property.AgeRange.Item2 )
                .OrderBy( x => x )
                .SequenceEqual( maxAges ) );
        }
        
        [ Test ]
        public void Then_Correct_Genders_Were_Returned( )
        {
            var genders = new [ ] 
            { 
                GenderEnum.Female,
                GenderEnum.Female, 
                GenderEnum.Female, 
                GenderEnum.Male,
                GenderEnum.Male, 
                GenderEnum.Male, 
                GenderEnum.Male, 
                GenderEnum.Male,
                GenderEnum.Male
            };
            CollectionAssert.AreEquivalent( genders, Result.Value
                .Select( x => x.Property.Gender ) );
        }
        
        [ Test ]
        public void Then_Correct_Follower_Counts_Were_Returned( )
        {
            var folowerCounts = new [ ] { 39, 4, 1, 73, 9, 2, 2, 1, 1 };
            Assert.True( Result.Value
                .Select( x => x.Count )
                .SequenceEqual( folowerCounts ) );
        }

        [ Test ]
        public void Then_Correct_Api_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<BaseRequestInsightParams>( x => x.period == "lifetime" && x.metric == "audience_gender_age" ) );
        }
    }
}