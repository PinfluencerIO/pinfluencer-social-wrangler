namespace Pinf.InstaService.BLL.Models.Insights
{
    public class CountryProperty
    {
        public CountryProperty(string countryCode)
        {
            CountryCode = countryCode;
        }

        public string CountryCode { get; }
    }
}