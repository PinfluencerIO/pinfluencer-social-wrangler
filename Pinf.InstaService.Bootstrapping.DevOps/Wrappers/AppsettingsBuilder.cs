using System.IO;
using Newtonsoft.Json;

namespace Pinf.InstaService.Bootstrapping.DevOps.Wrappers
{
    public class AppsettingsBuilder<T>
    {
        public AppsettingsBuilder(string filePath, T content)
        {
            var file = new FileInfo(filePath);
            file.Directory?.Create();
            var output = JsonConvert.SerializeObject(content, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}