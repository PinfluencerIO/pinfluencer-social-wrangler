using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceCountryRepositoryTests.MapMany
{
    public class When_Called : Given_An_InstagramAudienceCountryRepository
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
                                Value = Serializer.Deserialize<object>( "{\"EG\": 1,\"SG\": 1,\"AU\": 1,\"IN\": 1,\"CI\": 1,\"PH\": 1,\"GB\": 125,\"ES\": 1,\"US\": 6}" )
                            }
                        }
                    }
                }
            } );
            CollectionAssert.AreEquivalent( new[]
            {
                ( CountryEnum.EG, 1 ),
                ( CountryEnum.SG, 1 ),
                ( CountryEnum.AU, 1 ),
                ( CountryEnum.IN, 1 ),
                ( CountryEnum.CI, 1 ),
                ( CountryEnum.PH, 1 ),
                ( CountryEnum.GB, 125 ),
                ( CountryEnum.ES, 1 ),
                ( CountryEnum.US, 6 )
            }, result
                .Select( x => ( x.Property.CountryCode, x.Count ) ));
        }
    }
}