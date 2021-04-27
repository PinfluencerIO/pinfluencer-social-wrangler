using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.UserManagement.Dtos;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;

namespace Pinf.InstaService.Local.Sandbox
{
    internal class Program
    {
        private static void Main( string [ ] args )
        {
            var profile = new ApiClientFactory( ).Create(
                    new Uri( "https://mobile-pinfluencer.bubbleapps.io/version-test/api/1.1/obj/" ),
                    "" )
                .Get<TypeResponse<Profile>>( "profile/" );
        }
    }

    public class TestDto
    {
        public string Name { get; set; }
        public TestNestedDto Type { get; set; }
    }

    public class TestNestedDto
    {
        public int Prop { get; set; }
    }
}