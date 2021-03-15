namespace BLL.Models.Insights
{
    public class CountryProperty
    {
        public string CountryCode { get; }

        public CountryProperty(string countryCode)
        {
            CountryCode = countryCode;
        }
    }
}