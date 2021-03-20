namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    public class RequestInsightParams
    {
        public string metric { get; set; }

        public string period { get; set; }

        public int since { get; set; }

        public int until { get; set; }
    }
}