using System;
using System.Linq;
using System.Net.Sockets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Facebook.Factories;
using Pinfluencer.SocialWrangler.DAL.Facebook.Repositories;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.Local.Sandbox
{
    public static class Program
    {
        private static void Main( string [ ] args ) =>
            ( Activator.CreateInstance( AppDomain.CurrentDomain
                .GetAssemblies( )
                .SelectMany( t => t.GetTypes( ) )
                .First( t => t.IsClass && t.Namespace == "Pinfluencer.SocialWrangler.Local.Sandbox.LocalSandbox" ) ) as IRunnable )?
            .Run(  );
    }
}