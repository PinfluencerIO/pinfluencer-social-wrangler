using System.Collections.Generic;
using System.Linq;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll.Shared;
using Audience = Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble.Audience;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll
{
    public class When_Successful : When_Called
    {
        private OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> _result;

        protected override void When( )
        {
            MockBubbleClient
                .Get<IEnumerable<AudienceGender>>( Arg.Any<string>( ) )
                .Returns( ( HttpStatusCode.OK, new []
                {
                    new AudienceGender{ Audience = "123", Id = "1", Name = "Male", Percentage = 0.75 },
                    new AudienceGender{ Audience = "123", Id = "2", Name = "Female", Percentage = 0.25 }
                } ) );
            _result = Sut.GetAll( "123" );
        }

        [ Test ]
        public void Then_Correct_Audience_Gender_Ids_Are_Returned( )
        {
            Assert.True( _result.Value.Select( x => x.Id ).SequenceEqual( new []{ "1", "2" } ) );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Genders_Are_Returned( )
        {
            Assert.True( _result.Value.Select( x => x.Value ).SequenceEqual( new []{ GenderEnum.Male, GenderEnum.Female } ) );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Percentages_Are_Returned( )
        {
            Assert.True( _result.Value.Select( x => x.Percentage ).SequenceEqual( new []{ 0.75, 0.25 } ) );
        }
        
        [ Test ]
        public void Then_Success_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Success, _result ); }
        
        [ Test ]
        public void Then_Success_Event_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogInfo( Arg.Any<string>( ) );
        }
    }
}