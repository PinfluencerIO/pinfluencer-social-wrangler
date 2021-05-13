using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinfluencer.SocialWrangler.API.Filters;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;

namespace Pinfluencer.SocialWrangler.Tests.Unit.API.Filters.SimpleAuthTests
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

            Sut = new SimpleAuthActionFilter( MockConfiguration, MvcAdapter );
        }
    }
}