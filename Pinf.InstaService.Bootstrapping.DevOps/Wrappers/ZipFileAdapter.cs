using System.IO.Compression;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    public static class ZipFileAdapter
    {
        public static void CreateFromDirectory( string startPath, string zipPath )
        {
            ZipFile.CreateFromDirectory( startPath, zipPath );
        }
    }
}