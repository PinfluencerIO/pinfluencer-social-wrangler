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
            var data = new InstagramAudienceRepository(
                new FacebookDecorator( new FacebookClientFactory( ), new JsonSerialzierAdapter( new PinfluencerJsonResolver(  ) ) )
                {
                    Token =
                        "EAAiW6ZB06aXUBAJEigXWJrG69GoBWwOXcJN7zpItMiYRYhooy8tZByOwvGTVBmsEiur4LGG65FJi57xZBBZBORp9jfPRcxLiU5g5GTyCJ1gGriCixzgAEvJ2sDH0CfmE9sToZCy0uxdxRZAt5hwiYpuXzBEZCwh84b1snW0ZCDGIQzL8eGXKsCSpzrSuzbZBTdY9oZC4tTuW9lCfN4qo4fs8VszK0fIL3NRisZD"
                },
                new LoggerAdapter<InstagramAudienceRepository>(
                    new Logger<InstagramAudienceRepository>( new NullLoggerFactory( ) ) ), new CountryGetter( ) )
                .GetCountry( "17841405594881885" );
        }
    }

    internal class IOPort
    {
    }
}