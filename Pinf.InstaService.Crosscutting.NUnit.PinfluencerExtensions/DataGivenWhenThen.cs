using Facebook;
using NSubstitute;
using Pinf.InstaService.DAL.Common;

namespace Pinf.InstaService.Crosscutting.NUnit.PinfluencerExtensions
{
    public class DataGivenWhenThen<T> : PinfluencerGivenWhenThen<T> where T : class
    {
        protected FacebookContext FacebookContext;
        protected FacebookClient MockFacebookClient => FacebookContext.FacebookClient;
        
        protected override void Given( )
        {
            base.Given( );
            FacebookContext = new FacebookContext( );
            FacebookContext.FacebookClient = Substitute.For<FacebookClient>( );
        }
    }
}