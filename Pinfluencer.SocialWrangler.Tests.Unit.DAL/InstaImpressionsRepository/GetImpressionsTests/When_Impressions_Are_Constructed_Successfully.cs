using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository.GetImpressionsTests
{
    public class When_Impressions_Are_Constructed_Successfully : When_Called
    {
        private ObjectResult<IEnumerable<ContentImpressions>> _result;

        protected override void When( )
        {
            MockFacebookDecorator
                .Get<DataArray<Metric<int>>>( Arg.Any<string>( ), Arg.Any<object>( ) )
                .Returns( new DataArray<Metric<int>>
                {
                    Data = new []
                    {
                        new Metric<int>
                        {
                            Insights = new []
                            {
                                new Insight<int>
                                {
                                    Time = "2017-05-04T07:00:00+0000",
                                    Value = 4
                                },
                                new Insight<int>
                                {
                                    Time = "2017-05-05T07:00:00+0000",
                                    Value = 66
                                },
                                new Insight<int>
                                {
                                    Time = "2017-05-06T07:00:00+0000",
                                    Value = 123
                                }
                            }
                        }
                    }
                } );

            _result = SUT.Get( TestId );
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

        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}