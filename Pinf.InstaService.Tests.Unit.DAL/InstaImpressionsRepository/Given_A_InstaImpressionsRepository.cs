﻿using Facebook;
using NSubstitute;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram;
using Pinf.InstaService.DAL.Instagram.Repositories;

namespace Pinf.InstaService.Tests.Unit.DAL.InstaImpressionsRepository
{
    public class Given_A_InstaImpressionsRepository : PinfluencerGivenWhenThen<InstagramImpressionsRepository>
    {
        protected FacebookClient MockFacebookClient;

        protected override void Given( )
        {
            base.Given( );
            MockFacebookClient = Substitute.For<FacebookClient>( );

            Sut = new InstagramImpressionsRepository(
                new FacebookContext
                {
                    FacebookClient = MockFacebookClient,
                },
                MockLogger
            );
        }
    }
}