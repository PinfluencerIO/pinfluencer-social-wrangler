using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.API.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "instagram-insights" ) ]
    public class InstagramInsightsController : SocialWranglerController
    {
        private readonly ISocialAudienceFacade _socialAudienceFacade;
        private readonly ISocialContentFacade _socialContentFacade;

        public InstagramInsightsController( MvcAdapter mvcAdapter,
            ISocialAudienceFacade socialAudienceFacade,
            ISocialContentFacade socialContentFacade ) :
            base( mvcAdapter )
        {
            _socialAudienceFacade = socialAudienceFacade;
            _socialContentFacade = socialContentFacade;
        }

        [ Route( "" ) ]
        [ HttpGet ]
        //TODO: IMPLEMENT REFLECTION ONE TIME SET UP => STORE METHODS IN MEMORY AS FUNC<T> AND EXECUTE FASTER
        public IActionResult Get( [ FromQuery ] string user, [ FromQuery ] string metric )
        {
            try
            {
                var method = GetType( )
                    .GetMethods( BindingFlags.NonPublic | BindingFlags.Instance )
                    .First( x => x.GetCustomAttribute<ActionNameAttribute>( )?.Name.ToLower( ) == metric );
                return method.Invoke( this, new object [ ] { user } ) as IActionResult;
            }
            catch( Exception e ) when( e is ArgumentException || e is InvalidOperationException ||
                                       e is NullReferenceException )
            {
                return MvcAdapter.NotFoundError( "insight metric was not found" );
            }
        }

        [ NonAction ]
        [ ActionName( "impressions" ) ]
        private IActionResult getImpressions( string user )
        {
            var insights = _socialContentFacade.GetImpressions( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( new
            {
                Impressions = insights.Value
            } );
            return MvcAdapter.BadRequestError( "failed to fetch instagram impressions for user" );
        }

        [ NonAction ]
        [ ActionName( "audience-age" ) ]
        private IActionResult getAudienceAge( string user )
        {
            var insights = _socialAudienceFacade.GetAudienceAgeInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram audience age insights for user" );
        }

        [ NonAction ]
        [ ActionName( "audience-gender" ) ]
        private IActionResult getAudienceGender( string user )
        {
            var insights = _socialAudienceFacade.GetAudienceGenderInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram audience gender insights for user" );
        }

        [ NonAction ]
        [ ActionName( "audience-country" ) ]
        private IActionResult getAudienceCountry( string user )
        {
            var insights = _socialAudienceFacade.GetAudienceCountryInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram audience gender insights for user" );
        }
        
        [ NonAction ]
        [ ActionName( "reach" ) ]
        private IActionResult getReach( string user )
        {
            var insights = _socialContentFacade.GetReach( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram reach insights for user" );
        }
    }
}