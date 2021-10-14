using System;
using Aidan.Common.Core.Interfaces.Contract;
using Aidan.Common.Utils.Test;
using NSubstitute;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class PinfluencerGivenWhenThen<T> : GivenWhenThen<T> where T : class
    {
        protected ILoggerAdapter<T> MockLogger;

        protected IDateTimeAdapter MockDateTime { get; } = Substitute.For<IDateTimeAdapter>( );

        protected DateTime CurrentTime
        {
            get => MockDateTime.Now( );
            set => MockDateTime
                .Now( )
                .Returns( value );
        }

        protected override void Given( ) { MockLogger = Substitute.For<ILoggerAdapter<T>>( ); }
    }
}