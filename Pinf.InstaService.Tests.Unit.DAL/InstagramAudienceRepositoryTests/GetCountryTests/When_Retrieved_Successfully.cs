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

namespace Pinf.InstaService.Tests.Unit.DAL.InstagramAudienceRepositoryTests.GetCountryTests
{
    public class When_Retrieved_Successfully : Given_A_InstagramAudienceRepository
    {
        private OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> _result;

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
                                        { "M.55-64", 1 }
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
            _result = Sut.GetGenderAge( "123" );
        }

        [ Test ]
        public void Then_Graph_Api_Was_Called_Once( )
        {
            MockFacebookClient
                .Received( 1 )
                .Get( Arg.Any<string>( ), Arg.Any<object>( ) );
        }
        
        [ Test ]
        public void Then_Correct_Api_Endpoint_Was_Called( )
        {
            MockFacebookClient
                .Received( )
                .Get( "123/insights", Arg.Any<object>( ) );
        }
        
                
        [ Test ]
        public void Then_Correct_Api_Params_Were_Used( )
        {
            MockFacebookClient
                .Received( )
                .Get( Arg.Any<string>( ), Arg.Is<RequestInsightLifetimeParams>( x => x.period == "lifetime" && x.metric == "audience_gender_age" ) );
        }
        
        [ Test ]
        public void Then_Success_Was_Returned( )
        {
            Assert.AreEqual( OperationResultEnum.Success, _result.Status );
        }
        
        [ Test ]
        public void Then_Correct_Min_Age_Ranges_Were_Returned( )
        {
            var minAges = new [ ] { 18, 25, 45, 18, 25, 35, 45, 55 }
                .OrderBy( x => x );
            Assert.True( _result.Value
                .Select( x => x.Property.AgeRange.Item1 )
                .OrderBy( x => x )
                .SequenceEqual( minAges ) );
        }
        
        [ Test ]
        public void Then_Correct_Max_Age_Ranges_Were_Returned( )
        {
            var maxAges = new [ ] { 24, 34, 54, 24, 34, 44, 54, 64 }
                .OrderBy( x => x );
            Assert.True( _result.Value
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
                GenderEnum.Male 
            };
            Assert.True( _result.Value
                .Select( x => x.Property.Gender )
                .SequenceEqual( genders ) );
        }
    }
}