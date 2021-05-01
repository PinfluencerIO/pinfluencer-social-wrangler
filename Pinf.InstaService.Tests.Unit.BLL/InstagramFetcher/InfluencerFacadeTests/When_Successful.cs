﻿using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions;

namespace Pinf.InstaService.Tests.Unit.BLL.InstagramFetcher.InfluencerFacadeTests
{
    public class When_Successful : Given_A_InfluencerFacade
    {
        protected override void When( )
        {
            MockUserRepository
                .Get( Arg.Any<string>( ) )
                .Returns( new OperationResult<IUser>( GetUser( DefaultUser ), OperationResultEnum.Success ) );
            MockInstaUserRepository
                .GetUsers( )
                .Returns( new OperationResult<IEnumerable<InstaUser>>( new [ ]
                {
                    new InstaUser
                    {
                        Bio = "This is an example",
                        Followers = 212,
                        Handle = "examplehandle",
                        Id = "654321",
                        Name = "Aidan Gannon"
                    }
                }, OperationResultEnum.Success ) );
            MockUserRepository
                .CreateInfluencer( Arg.Any<Influencer>( ) )
                .Returns( OperationResultEnum.Success );
            Sut.OnboardInfluencer( "123" );
        }

        [ Test ]
        public void Then_Valid_Influencer_Was_Created( )
        {
            MockUserRepository
                .Received( )
                .CreateInfluencer( Arg.Is<Influencer>( x =>
                    x.Age == 21 &&
                    x.Bio == "This is an example" &&
                    x.Gender == GenderEnum.Male &&
                    x.Location == "London" &&
                    x.User.Id == "12345" &&
                    x.InstagramHandle == "examplehandle" ) );
        }
    }
}