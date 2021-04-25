using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests
{
    public class Given_A_SimpleAuthFilter : AspActionFilterGivenWhenThen<SimpleAuthActionFilter>
    {
        protected const string ApiKeyName = "Simple-Auth-Key";
        protected const string ApiKey = "asdffdsa";

        protected IConfiguration MockConfiguration;

        protected override void Given( )
        {
            base.Given( );

            MockConfiguration = Substitute.For<IConfiguration>( );

            Sut = new SimpleAuthActionFilter( MockConfiguration );
        }
    }
}