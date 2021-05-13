﻿using NSubstitute;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.AudienceRepositoryTests
{
    public class Given_An_AudienceRepository : DataGivenWhenThen<AudienceRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            Sut = new AudienceRepository( MockBubbleDataHandler );
        }
    }
}