namespace Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Deploy
{
    public class ProcLineDto
    {
        public string Name { get; set; } = "web";
        public string Location { get; set; } = "./";
        public string Namespace { get; set; }
        public int Port { get; set; } = 5000;
    }
}