using System;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Pinf.InstaService.Core.Interfaces.Models;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions
{
    public class PinfluencerGivenWhenThen<T> : GivenWhenThen<T>
    {
        protected IUser GetUser( FakeUserProps userProps ) => FakeUserModel.GetFake( MockDateTime, userProps );

        protected ILoggerAdapter MockLogger;

        protected override void Given( ) { MockLogger = Substitute.For<ILoggerAdapter>( ); }

        protected IDateTimeAdapter MockDateTime { get; } = Substitute.For<IDateTimeAdapter>( );

        protected DateTime CurrentTime
        {
            set => MockDateTime.Now( ).Returns( value );
        }
        
        
    }
}