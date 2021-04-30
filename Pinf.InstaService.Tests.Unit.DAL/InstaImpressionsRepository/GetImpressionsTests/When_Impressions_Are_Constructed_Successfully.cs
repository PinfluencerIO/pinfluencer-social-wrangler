using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests
{
    public class When_Impressions_Are_Constructed_Successfully : When_Get_Impressions_Was_Called
    {
        private OperationResult<IEnumerable<InstaProfileViewsInsight>> _result;

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
                            name = "impressions",
                            period = "day",
                            values = new dynamic [ ]
                            {
                                new
                                {
                                    value = 4,
                                    end_time = "2017-05-04T07:00:00+0000"
                                },
                                new
                                {
                                    value = 66,
                                    end_time = "2017-05-05T07:00:00+0000"
                                },
                                new
                                {
                                    value = 123,
                                    end_time = "2017-05-06T07:00:00+0000"
                                }
                            },
                            title = "Impressions",
                            description = "Total number of times this profile has been seen",
                            id = "17841400008460056/insights/impressions/day"
                        }
                    }
                } );

            _result = Sut.GetImpressions( TestId );
        }

        [ Test ]
        public void Then_Impressions_Counts_Are_Valid( )
        {
            Assert.True( new [ ] { 4, 66, 123 }.SequenceEqual( _result.Value.Select( x => x.Count ) ) );
        }

        [ Test ]
        public void Then_Impressions_Years_Are_Valid( )
        {
            Assert.True( new [ ] { 2017, 2017, 2017 }.SequenceEqual( _result.Value.Select( x => x.Time.Year ) ) );
        }

        [ Test ]
        public void Then_Impressions_Months_Are_Valid( )
        {
            Assert.True( new [ ] { 5, 5, 5 }.SequenceEqual( _result.Value.Select( x => x.Time.Month ) ) );
        }

        [ Test ]
        public void Then_Impressions_Days_Are_Valid( )
        {
            Assert.True( new [ ] { 4, 5, 6 }.SequenceEqual( _result.Value.Select( x => x.Time.Day ) ) );
        }

        [ Test ]
        public void Then_Response_Is_Successful( ) { Assert.AreEqual( OperationResultEnum.Success, _result.Status ); }
    }
}