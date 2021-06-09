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
                        .First( t =>
                            t.IsClass && t.Namespace == "Pinfluencer.SocialWrangler.Local.Sandbox.LocalSandbox" ) ) as
                    IRunnable )?
                .Run( );
        }
    }
}