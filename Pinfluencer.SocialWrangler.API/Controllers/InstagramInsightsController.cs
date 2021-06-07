﻿using System;
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
        private readonly ISocialFacade _socialFacade;

        public InstagramInsightsController( ISocialFacade socialFacade, MvcAdapter mvcAdapter ) :
            base( mvcAdapter )
        {
            _socialFacade = socialFacade;
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
            var insights = _socialFacade.GetImpressions( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram impressions for user" );
        }

        [ NonAction ]
        [ ActionName( "audience-age" ) ]
        private IActionResult getAudienceAge( string user )
        {
            var insights = _socialFacade.GetAudienceAgeInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram audience age insights for user" );
        }

        [ NonAction ]
        [ ActionName( "audience-gender" ) ]
        private IActionResult getAudienceGender( string user )
        {
            var insights = _socialFacade.GetAudienceGenderInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram audience gender insights for user" );
        }

        [ NonAction ]
        [ ActionName( "audience-country" ) ]
        private IActionResult getAudienceCountry( string user )
        {
            var insights = _socialFacade.GetAudienceCountryInsights( user );
            if( insights.Status != OperationResultEnum.Failed ) return MvcAdapter.OkResult( insights.Value );
            return MvcAdapter.BadRequestError( "failed to fetch instagram audience gender insights for user" );
        }
    }
}