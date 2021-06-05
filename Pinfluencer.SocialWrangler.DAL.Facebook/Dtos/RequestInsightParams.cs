namespace Pinfluencer.SocialWrangler.DAL.Facebook.Dtos
{
    public class RequestInsightParams
    {
        public int since { get; set; }

        public int until { get; set; }

        public string metric { get; set; }

        public string period { get; set; }
    }
}