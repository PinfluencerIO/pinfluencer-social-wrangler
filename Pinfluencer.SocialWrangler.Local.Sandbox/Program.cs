using System;
using System.Linq;

namespace Pinfluencer.SocialWrangler.Local.Sandbox
{
    public static class Program
    {
        private static void Main( string [ ] args )
        {
            ( Activator.CreateInstance( AppDomain.CurrentDomain
                        .GetAssemblies( )
                        .SelectMany( t => t.GetTypes( ) )
                        .First( t => t.Name == "Runner" ) ) as
                    IRunnable )?
                .Run( );
        }
    }
}