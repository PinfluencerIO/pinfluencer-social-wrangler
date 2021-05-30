using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceGenderAgeRepositoryTests.MapMany
{
    public class When_Called : Given_An_InstagramGenderAgeRepository
    {
        [ Test ]
        public void Then_Mapping_Is_Correct( )
        {
            var result = SUT.MapMany( new DataArray<Metric<object>>
            {
                Data = new [ ]
                {
                    new Metric<object>
                    {
                        Insights = new [ ]
                        {
                            new Insight<object>
                            {
                                Time = "2021-05-30T07:00:00+0000",
                                Value = JsonConvert.DeserializeObject( "{\"F.18-24\": 36,\"F.25-34\": 4,\"F.45-54\": 1,\"M.18-24\": 75,\"M.25-34\": 9,\"M.35-44\": 1,\"M.45-54\": 2,\"M.55-64\": 1,\"M.65+\": 1,\"U.18-24\": 7,\"U.25-34\": 1}" )
                            }
                        }
                    }
                }
            } );
            CollectionAssert.AreEquivalent( new (GenderEnum Male, int, int?, int)[]
            {
                ( GenderEnum.Female, 18, 24, 36 ),
                ( GenderEnum.Female, 25, 34, 4 ),
                ( GenderEnum.Female, 45, 54, 1 ),
                ( GenderEnum.Male, 18, 24, 75 ),
                ( GenderEnum.Male, 25, 34, 9 ),
                ( GenderEnum.Male, 35, 44, 1 ),
                ( GenderEnum.Male, 45, 54, 2 ),
                ( GenderEnum.Male, 55, 64, 1 ),
                ( GenderEnum.Male, 65, null, 1 ),
                ( GenderEnum.Unknown, 18, 24, 7 ),
                ( GenderEnum.Unknown, 25, 34, 1 )
            }, result
                .Select( x => ( x.Property.Gender,
                    x.Property.AgeRange.Item1,
                    x.Property.AgeRange.Item2,
                    x.Count ) ));
        }
    }
}