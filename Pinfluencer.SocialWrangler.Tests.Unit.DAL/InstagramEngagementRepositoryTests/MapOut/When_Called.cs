using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramEngagementRepositoryTests.MapOut
{
    public class When_Called : Given_An_InstagramEngagementRepository
    {
        [ Test ]
        public void Then_Mapping_Is_Correct( )
        {
            var data = new DataArray<Metric<int>>
            {
                Data = new [ ]
                {
                    new Metric<int>
                    {
                        Insights = new [ ]
                        {
                            new Insight<int>
                            {
                                Value = 43
                            }
                        }
                    }
                }
            };
            var result = SUT.MapOut( data );
            Assert.AreEqual( 43, result );
        }
    }
}