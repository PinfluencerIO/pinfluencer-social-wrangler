using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Facebook;
using Newtonsoft.Json;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models;
using Pinf.InstaService.Core.Models.User;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.UserManagement;
using Pinf.InstaService.DAL.UserManagement.Common;
using Pinf.InstaService.DAL.UserManagement.Dtos.Bubble;
using Pinf.InstaService.DAL.UserManagement.Repositories;
using Influencer = Pinf.InstaService.DAL.UserManagement.Dtos.Bubble.Influencer;
using InfluencerModel = Pinf.InstaService.Core.Models.User.Influencer;

using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Pinf.InstaService.Local.Sandbox
{
    internal class Program
    {
        private static void Main( string [ ] args ) => Console.Write( "" );
    }

}