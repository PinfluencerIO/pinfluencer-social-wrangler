using System.IO.Compression;

namespace Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Wrappers
{
    public static class ZipFileAdapter
    {
        public static void CreateFromDirectory( string startPath, string zipPath )
        {
            ZipFile.CreateFromDirectory( startPath, zipPath );
        }
    }
}