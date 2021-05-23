using NUnit.Framework;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions
{
    //TODO: add middleware test class
    public abstract class GivenWhenThen<T>
    {
        protected T SUT;

        [ SetUp ]
        public void SetUp( )
        {
            Given( );
            When( );
        }

        protected virtual void Given( ) { }

        protected virtual void When( ) { }
    }
}