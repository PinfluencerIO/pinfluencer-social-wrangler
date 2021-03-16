using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;
using Tests.Unit.API.FacebookMiddlware.Shared;
using When_Error_Occurs = Tests.Unit.API.Auth0Middlware.Shared.When_Error_Occurs;

namespace Tests.Unit.API.Auth0Middlware
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