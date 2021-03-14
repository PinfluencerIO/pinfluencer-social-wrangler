using NUnit.Framework;

namespace Crosscutting.Testing.Extensions
{
    public abstract class GivenWhenThen<T>
    {
        protected T Sut;

        [SetUp]
        public void SetUp()
        {
            Given();
            When();
        }

        protected virtual void Given()
        {
            
        }

        protected virtual void When()
        {
            
        }
    }
}