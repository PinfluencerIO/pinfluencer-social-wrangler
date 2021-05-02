namespace Pinf.InstaService.DAL.Instagram.Dtos
{
    public class BaseRequestInsightParams
    {
        public string metric { get; set; }

        public virtual string period { get; set; }
    }
}