using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.Crosscutting.NUnit.Extensions;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests
{
    public class Given_A_Simple_Auth_Filter : AspActionFilterGivenWhenThen<SimpleAuth>
    {
        protected IConfiguration MockConfiguration;
        protected IHeaderDictionary MockHeaderDictionary;

        protected override void Given( )
        {
            base.Given(  );
            
            MockConfiguration = Substitute.For<IConfiguration>( );

            Sut = new SimpleAuth( MockConfiguration );
        }
    }
}