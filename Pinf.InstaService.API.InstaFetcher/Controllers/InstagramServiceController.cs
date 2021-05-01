using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.Filters;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.API.InstaFetcher.Controllers
{
    [ ServiceFilter( typeof( Auth0ActionFilter ), Order = 2 ) ]
    [ ServiceFilter( typeof( FacebookActionFilter ), Order = 3 ) ]
    public abstract class InstagramServiceController : PinfluencerController
    {
        protected static NotFoundObjectResult GetNotFoundError( string message ) => new NotFoundObjectResult( new ErrorDto { ErrorMsg = message } );
        
        protected UnauthorizedObjectResult GetUnauthorizedError( string message ) => new UnauthorizedObjectResult( new ErrorDto { ErrorMsg = message } );

        protected static BadRequestObjectResult GetBadRequestError( string message ) => new BadRequestObjectResult( new ErrorDto { ErrorMsg = message } );

        protected static OkObjectResult GetCollection<T>( IEnumerable<T> collection ) =>
            new OkObjectResult( new CollectionDto<T> { Collection = collection } );

        protected OkObjectResult GetObject<T>( T objectVal ) =>
            new OkObjectResult( objectVal );
    }
}