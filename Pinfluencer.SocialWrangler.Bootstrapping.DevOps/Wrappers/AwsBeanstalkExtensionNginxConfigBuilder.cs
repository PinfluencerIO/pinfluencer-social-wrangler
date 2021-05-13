using System;
using System.IO;
using Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Deploy;

namespace Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Wrappers
{
    public class AwsBeanstalkExtensionNginxConfigBuilder
    {
        private readonly string _path;

        public AwsBeanstalkExtensionNginxConfigBuilder( string path ) { _path = path; }

        public AwsBeanstalkExtensionNginxConfigBuilder AddReverseProxy( NginxReverseProxyDto config )
        {
            using var fs =
                File.AppendText( $"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}" );
            var firstLine = $"location {config.Url} " + "{" + Environment.NewLine;
            var secondLine = $"    proxy_pass  http://127.0.0.1:{config.Port}/;{Environment.NewLine}";
            var thirdLine = "}";
            fs.Write( $"{firstLine}{secondLine}{thirdLine}" );
            return this;
        }

        public AwsBeanstalkExtensionNginxConfigBuilder AddTextResponse( NginxTextResponseDto config )
        {
            using var fs =
                File.AppendText( $"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}" );
            var firstLine = $"{Environment.NewLine}location {config.Url} " + "{" + Environment.NewLine;
            var secondLine = $"    return {config.Status} '{config.Text}';{Environment.NewLine}";
            var thirdLine = "}" + Environment.NewLine;
            fs.Write( $"{firstLine}{secondLine}{thirdLine}" );
            return this;
        }

        public AwsBeanstalkExtensionNginxConfigBuilder Create( )
        {
            var file = new FileInfo(
                $"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}" );
            file.Directory?.Create( );
            using var fs =
                File.Create( $"{_path}{Path.DirectorySeparatorChar}{AwsBeanstalkConstants.NginxExtensionFile}" );
            return this;
        }
    }
}