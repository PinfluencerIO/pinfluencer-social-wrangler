using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pinf.InstaService.API.InstaFetcher.ResponseDtos;

namespace Pinf.InstaService.API.InstaFetcher.Extensions
{
    public static class MvcExtensions
    {
        public static OkObjectResult Success( string message ) => new OkObjectResult( new SuccessDto{ Msg = message } );

        public static NotFoundObjectResult NotFoundError( string message ) => new NotFoundObjectResult( new ErrorDto { ErrorMsg = message } );
        
        public static UnauthorizedObjectResult UnauthorizedError( string message ) => new UnauthorizedObjectResult( new ErrorDto { ErrorMsg = message } );

        public static BadRequestObjectResult BadRequestError( string message ) => new BadRequestObjectResult( new ErrorDto { ErrorMsg = message } );

        public static OkObjectResult OkResult<T>( this IEnumerable<T> collection ) =>
            new OkObjectResult( new CollectionDto<T> { Collection = collection } );

        public static OkObjectResult OkResult<T>( this T objectVal ) =>
            new OkObjectResult( objectVal );
    }
}