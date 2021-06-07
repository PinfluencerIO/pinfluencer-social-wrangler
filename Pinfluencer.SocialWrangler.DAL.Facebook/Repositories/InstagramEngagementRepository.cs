using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramEngagementRepository : IDataMappableOut<int,DataArray<Metric<int>>>, ISocialEngagementRepository
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