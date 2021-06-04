using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Pinfluencer.SocialWrangler.API
{
    public class Program
    {
        public static void Main( string [ ] args )
        {
            Host.CreateDefaultBuilder( args )
                .ConfigureWebHostDefaults( webBuilder => { webBuilder.UseStartup<Startup>( ); } )
                .UseServiceProviderFactory( new DefaultServiceProviderFactory() )
                .Build( )
                .Run( );
        }
    }
}