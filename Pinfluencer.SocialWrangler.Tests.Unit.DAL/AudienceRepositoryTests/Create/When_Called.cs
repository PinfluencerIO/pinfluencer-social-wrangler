using System;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using AudienceModel = Pinfluencer.SocialWrangler.Core.Models.Audience;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceRepositoryTests.Create
{
    [ TestFixture( OperationResultEnum.Success ) ]
    [ TestFixture( OperationResultEnum.Failed ) ]
    public class When_Called : Given_An_AudienceRepository
    {
        private readonly OperationResultEnum _operationResult;
        private OperationResultEnum _result;

        public When_Called( OperationResultEnum operationResult ) { _operationResult = operationResult; }

        protected override void When( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Any<AudienceModel>( ), Arg.Any<Func<AudienceModel, Audience>>( ) )
                .Returns( _operationResult );
            _result = SUT.Create( new AudienceModel( ) );
        }

        [ Test ]
        public void Then_Correct_Model_Was_Passed_In( )
        {
            MockBubbleDataHandler
                .Create( Arg.Any<string>( ), Arg.Is<AudienceModel>( x => x.Id == null &&
                                                                         x.AudienceAge == null &&
                                                                         x.AudienceGender == null &&
                                                                         x.AudienceCountry == null ),
                    Arg.Any<Func<AudienceModel, Audience>>( ) );
        }

        [ Test ]
        public void Then_Correct_Audience_Was_Created( )
        {
            var mapResult = SUT.EmptyModelMap( new AudienceModel( ) );
            Assert.True( mapResult.AudienceAge == null &&
                         mapResult.AudienceGender == null &&
                         mapResult.AudienceLocation == null );
        }

        [ Test ]
        public void Then_Correct_Resource_Is_Used( )
        {
            MockBubbleDataHandler
                .Create( Arg.Is( "audience" ), Arg.Any<AudienceModel>( ), Arg.Any<Func<AudienceModel, Audience>>( ) );
        }

        [ Test ]
        public void Then_Valid_Status_Is_Returned( ) { Assert.AreEqual( _operationResult, _result ); }
    }
}