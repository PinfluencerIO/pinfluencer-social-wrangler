using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramEngagementRepositoryTests
{
    public class Given_An_InstagramEngagementRepository : DataGivenWhenThen<InstagramEngagementRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramEngagementRepository( MockFacebookDataHandler );
        }
    }

    public class InstagramEngagementRepository : IDataMappableOut<int,DataArray<Metric<int>>>
    {
        private readonly IFacebookDataHandler<InstagramEngagementRepository> _facebookDataHandler;

        public InstagramEngagementRepository( IFacebookDataHandler<InstagramEngagementRepository> facebookDataHandler )
        {
            _facebookDataHandler = facebookDataHandler;
        }

        public ObjectResult<int> Get( string media )
        {
            return _facebookDataHandler
                .Read<int, DataArray<Metric<int>>>( $"{media}/insights",
                    MapOut,
                    default,
                    new RequestInsightParams
                    {
                        metric = "engagement"
                    } );
        }

        public int MapOut( DataArray<Metric<int>> dto ) 
        { 
            return dto
                .Data
                .First( )
                .Insights
                .First( )
                .Value; 
        }
    }
}