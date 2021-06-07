using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramInsightsDataHandlerTests.MapMany
{
    public class When_Called : Given_An_InstagramInsightsDataHandler
    {
        [ Test ]
        public void Then_Mapping_Is_Correct( )
        {
            var result = SUT.MapMany( new DataArray<Metric<int>>
            {
                Data = new [ ]
                {
                    new Metric<int>
                    {
                        Insights = new [ ]
                        {
                            new Insight<int>
                            {
                                Time = "2020-12-13T08:00:00+00:00",
                                Value = 43
                            },
                            new Insight<int>
                            {
                                Time = "2020-12-14T08:00:00+00:00",
                                Value = 156
                            },
                            new Insight<int>
                            {
                                Time = "2020-12-15T08:00:00+00:00",
                                Value = 41
                            },
                            new Insight<int>
                            {
                                Time = "2020-12-16T08:00:00+00:00",
                                Value = 13
                            },
                            new Insight<int>
                            {
                                Time = "2020-12-17T08:00:00+00:00",
                                Value = 48
                            },
                            new Insight<int>
                            {
                                Time = "2020-12-18T08:00:00+00:00",
                                Value = 14
                            },
                            new Insight<int>
                            {
                                Time = "2020-12-19T08:00:00+00:00",
                                Value = 23
                            }
                        }
                    }
                }
            } );
            CollectionAssert.AreEquivalent( new [ ]
            {
                ( 43, "12/13/2020" ),
                ( 156, "12/14/2020" ),
                ( 41, "12/15/2020" ),
                ( 13, "12/16/2020" ),
                ( 48, "12/17/2020" ),
                ( 14, "12/18/2020" ),
                ( 23, "12/19/2020" )
            }, result
                .Select( x => 
                    ( x.Count, x
                        .Time
                        .ToString( "MM/dd/yyyy" ) ) ) );
        }
    }
}