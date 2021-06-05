using System;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.Core
{
    //TODO: provide message param to allow for meaningful error messages
    public class OperationResult<T>
    {
        [ Obsolete( "prefer object initialization" ) ]
        public OperationResult( T value, OperationResultEnum status, string msg = null )
        {
            Value = value;
            Status = status;
            Msg = msg;
        }

        public OperationResult( ) { }

        public string Msg { get; set; }

        public T Value { get; set; }

        public OperationResultEnum Status { get; set; }
    }
}