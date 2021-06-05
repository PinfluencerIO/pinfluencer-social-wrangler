using System;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;

namespace Pinfluencer.SocialWrangler.Tests.Unit.BLL.ValidateInstaAudienceAgeRange.Shared
{
    public abstract class
        Given_A_ValidateInstaAudienceAgeRange : GivenWhenThen<
            Core.Models.Validation.ValidateInstaAudienceAgeRange>
    {
        protected int AgeMax;
        protected int AgeMin;
        protected bool Result;

        protected override void When( )
        {
            SUT = new Core.Models.Validation.ValidateInstaAudienceAgeRange
                { AgeRange = new Tuple<int, int>( AgeMin, AgeMax ) };

            Result = SUT.Validate( );
        }
    }
}