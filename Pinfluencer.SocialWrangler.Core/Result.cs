using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core
{
    public class Result
    {
        [ Obsolete( "prefer object initialization" ) ]
        public Result( OperationResultEnum status, string msg = null )
        {
            Status = status;
            Msg = msg;
        }
        
        public Result( ) { }
    
        public OperationResultEnum Status { get; set; }
        public string Msg { get; set; }

        public static Result Error( string msg )
        {
            return new Result
            {
                Status = OperationResultEnum.Failed,
                Msg = msg
            };
        }
        
        public static Result Success( )
        {
            return new Result
            {
                Status = OperationResultEnum.Success
            };
        }
    }
}