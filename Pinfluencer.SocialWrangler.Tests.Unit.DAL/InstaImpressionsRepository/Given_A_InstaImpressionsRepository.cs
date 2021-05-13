﻿using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Instagram.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstaImpressionsRepository
{
    public class Given_A_InstaImpressionsRepository : DataGivenWhenThen<InstagramImpressionsRepository>
    {
        protected override void Given( )
        {
            base.Given( );

            Sut = new InstagramImpressionsRepository(
                FacebookContext,
                MockLogger
            );
        }
    }
}