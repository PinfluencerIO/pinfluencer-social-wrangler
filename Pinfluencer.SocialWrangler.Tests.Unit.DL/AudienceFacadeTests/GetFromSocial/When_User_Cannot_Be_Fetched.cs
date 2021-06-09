using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial
{
    public class When_User_Cannot_Be_Fetched : When_Called
    {
        private ObjectResult<Audience> _result;

        protected override void When( )
        {
            base.When( );
            MockSocialInsightsUserFacade
                .GetFirstUser( )
                .Returns( new ObjectResult<SocialInsightsUser>
                {
                    Status = OperationResultEnum.Failed,
                    Value = null
                } );
            _result = SUT.GetFromSocial( );
        }
        
        [ Test ]
        public void Then_Result_Is_Successful( )
        {
            ResultAssert.IsFailiure( _result );
        }
    }
}