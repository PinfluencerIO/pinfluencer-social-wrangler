using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Aidan.Common.Utils.Test;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial
{
    public class When_Audience_Age_Cannot_Be_Fetched : When_Called
    {
        private ObjectResult<Audience> _result;

        protected override void When( )
        {
            base.When( );
            MockSocialAudienceFacade
                .GetAudienceAgeInsights( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>
                {
                    Status = OperationResultEnum.Failed,
                    Value = Enumerable.Empty<AudiencePercentage<AgeProperty>>(  )
                } );
            _result = SUT.GetFromSocial( );
        }
        
        [ Test ]
        public void Then_Result_Is_Warning( )
        {
            ResultAssert.IsWarning<Audience>( _result );
        }
        
        [ Test ]
        public void Then_Correct_Audience_Was_Returned( )
        {
            CollectionAssert.IsEmpty( _result.Value.AudienceAge );
        }
    }
}