using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.AudienceFacadeTests.GetFromSocial
{
    public class When_Audience_Country_Cannot_Be_Fetched : When_Called
    {
        private ObjectResult<Audience> _result;

        protected override void When( )
        {
            base.When( );
            MockSocialAudienceFacade
                .GetAudienceCountryInsights( Arg.Any<string>( ) )
                .Returns( new ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>>
                {
                    Status = OperationResultEnum.Failed,
                    Value = Enumerable.Empty<AudiencePercentage<CountryProperty>>(  )
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
            CollectionAssert.IsEmpty( _result.Value.AudienceCountry );
        }
    }
}