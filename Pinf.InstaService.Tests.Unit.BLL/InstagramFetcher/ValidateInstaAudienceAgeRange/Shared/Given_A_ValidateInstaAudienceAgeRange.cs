using System;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.ValidateInstaAudienceAgeRange.Shared
{
    public abstract class
        Given_A_ValidateInstaAudienceAgeRange : GivenWhenThen<InstaService.BLL.Models.Validation.ValidateInstaAudienceAgeRange>
    {
        protected int AgeMax;
        protected int AgeMin;
        protected bool Result;

        protected override void When()
        {
            Sut = new InstaService.BLL.Models.Validation.ValidateInstaAudienceAgeRange
                {AgeRange = new Tuple<int, int>(AgeMin, AgeMax)};

            Result = Sut.Validate();
        }
    }
}