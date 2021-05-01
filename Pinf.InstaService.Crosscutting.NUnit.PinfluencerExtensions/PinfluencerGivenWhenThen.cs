using System;
using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions
{
    public class PinfluencerGivenWhenThen<T> : GivenWhenThen<T>
    {
        public IUser GetUser( FakeUserProps userProps ) => FakeUserModel.GetFake( MockDateTime, userProps );

        public IDateTimeAdapter MockDateTime { get; } = Substitute.For<IDateTimeAdapter>( );

        public DateTime CurrentTime
        {
            set => MockDateTime.Now( ).Returns( value );
        }
    }
}