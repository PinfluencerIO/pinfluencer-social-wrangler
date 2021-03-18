using NUnit.Framework;

namespace Crosscutting.Testing.Extensions
{
    //TODO: add middleware test class
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