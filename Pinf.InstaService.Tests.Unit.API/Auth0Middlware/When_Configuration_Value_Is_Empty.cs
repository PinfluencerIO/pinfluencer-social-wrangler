using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.API.Auth0Middlware.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Auth0Middlware
{
    [TestFixture("Id")]
    [TestFixture("Secret")]
    [TestFixture("Domain")]
    [TestFixture("ManagementDomain")]
    public class When_Configuration_Value_Is_Empty : When_Error_Occurs
    {
        private readonly string _key;

        public When_Configuration_Value_Is_Empty(string key)
        {
            _key = key;
        }

        protected override void When()
        {
            AddDefaultConfiguration();
            AddConfiguration(_key, default);
            SetConfiguration();

            base.When();
        }
    }
}