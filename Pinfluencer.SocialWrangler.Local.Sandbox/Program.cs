using System.Net.Sockets;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.User;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.Local.Sandbox
{
    internal class BenchContext
    {
        private readonly Socket _server;
        private readonly IOPort _digIn;
        private readonly IOPort _analIn;
        public BenchContext( Socket server, IOPort digIn, IOPort analIn )
        {
            _server = server;
            _digIn = digIn;
            _analIn = analIn;
        }

        private static void Main( string [ ] args )
        {
            var value = $"{typeof( User )}";
        }
    }

    internal class IOPort
    {
    }
}