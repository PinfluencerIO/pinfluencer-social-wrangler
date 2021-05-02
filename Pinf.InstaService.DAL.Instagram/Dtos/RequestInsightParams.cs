namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    public class RequestInsightParams : BaseRequestInsightParams
    {
        public int since { get; set; }

        public int until { get; set; }
    }
}