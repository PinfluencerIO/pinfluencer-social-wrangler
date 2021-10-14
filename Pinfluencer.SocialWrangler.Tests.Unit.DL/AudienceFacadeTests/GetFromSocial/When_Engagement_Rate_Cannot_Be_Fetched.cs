using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Aidan.Common.Utils.Test;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial
{
    public class When_Engagement_Rate_Cannot_Be_Fetched : When_Called
    {
        private ObjectResult<Audience> _result;

        protected override void When( )
        {
            base.When( );
            MockSocialContentFacade
                .GetEngagementRate( )
                .Returns( new ObjectResult<double>
                {
                    Status = OperationResultEnum.Failed,
                    Value = default
                } );
            _result = SUT.GetFromSocial( );
        }
        
        [ Test ]
        public void Then_Result_Is_Warning( )
        {
            ResultAssert.IsWarning( _result );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Was_Returned( )
        {
            Assert.AreEqual( 0, _result.Value.EngagementRate );
        }
    }
}