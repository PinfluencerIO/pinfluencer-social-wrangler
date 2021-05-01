using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.Extensions;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;
using Pinf.InstaService.BLL.Facades;
using Pinf.InstaService.Core.Enum;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    //TODO: implement auto-mapper
    [ Route( "instagram_insights" ) ]
    public class InstagramInsightsController : InstagramServiceController
    {
        private readonly InstagramFacade _instagramFacade;

        public InstagramInsightsController( InstagramFacade instagramFacade ) { _instagramFacade = instagramFacade; }

        [ Route( "" ) ]
        [ HttpGet ]
        //TODO: IMPLEMENT REFLECTION ONE TIME SET UP => STORE METHODS IN MEMORY AS FUNC<T> AND EXECUTE FASTER
        public IActionResult Get( [ FromQuery ] string user, [ FromQuery ] string metric )
        {
            try
            {
                var method = GetType( )
                    .GetMethods( BindingFlags.NonPublic | BindingFlags.Instance )
                    .First( x => x.GetCustomAttribute<ActionNameAttribute>()?.Name.ToLower( ) == metric );
                return method.Invoke( this, new object [ ] { user } ) as IActionResult;
            }
            catch( Exception e ) when( e is ArgumentException || e is InvalidOperationException || e is NullReferenceException )
            {
                return MvcExtensions.NotFoundError( "insight metric was not found" );
            }
        }

        [ NonAction ]
        [ ActionName( "profile_impressions" ) ]
        private IActionResult GetImpressions( [ FromQuery ] string user )
        {
            var insights = _instagramFacade.GetUserInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return insights.Value.OkResult( );
            return MvcExtensions.BadRequestError( "failed to fetch instagram impressions for user" );
        }
    }
}