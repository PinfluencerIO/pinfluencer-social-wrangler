using System;
using System.Collections.Generic;
using System.Net.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;
using Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get.Shared;

namespace Pinf.InstaService.Tests.Unit.DAL.UserRepositoryTests.Get
{
    [ TestFixtureSource( nameof( fixture ) ) ]
    public class When_Network_Error_Or_Parsing_Error_Occurs : When_Bubble_Error_Occurs
    {
        private readonly Exception _exception;

        public When_Network_Error_Or_Parsing_Error_Occurs( Exception exception ) { _exception = exception; }

        private static IEnumerable<Exception> fixture = new Exception [ ]
        {
            new ArgumentException( "uri was null" ),
            new HttpRequestException( "network error" )
        };

        protected override void When( )
        {
            MockBubbleClient
                .Get<TypeResponse<Profile>>( Arg.Any<string>( ) )
                .Throws( _exception );
            Result = Sut.Get( "1234" );
        }
    }
}