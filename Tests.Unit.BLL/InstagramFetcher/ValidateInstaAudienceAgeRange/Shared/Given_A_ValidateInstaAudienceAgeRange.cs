using System;
using Crosscutting.Testing.Extensions;

namespace Tests.Unit.BLL.InstagramFetcher.ValidateInstaAudienceAgeRange.Shared
{
    public abstract class
        Given_A_ValidateInstaAudienceAgeRange : GivenWhenThen<
            global::BLL.Models.Validation.ValidateInstaAudienceAgeRange>
    {
        protected int AgeMax;
        protected int AgeMin;
        protected bool Result;

        protected override void When()
        {
            Sut = new global::BLL.Models.Validation.ValidateInstaAudienceAgeRange
                {AgeRange = new Tuple<int, int>(AgeMin, AgeMax)};

            Result = Sut.Validate();
        }
    }
}