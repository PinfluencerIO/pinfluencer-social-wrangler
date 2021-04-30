using System;
using Facebook;
using Newtonsoft.Json;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.UserManagement;
using Pinf.InstaService.DAL.UserManagement.Common;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.DAL.UserManagement.Repositories;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Pinf.InstaService.Local.Sandbox
{
    internal class Program
    {
        private static void Main( string [ ] args )
        {
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