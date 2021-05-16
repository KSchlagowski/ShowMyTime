namespace ShowMyTime.Domain.Models
{
    public class ConfigurationModel
    {
        public string BaseApiPath { get; set; }
        public string UserTimeZone { get; set; }
        public string AllTimeZonesApiPath { get; set; }
    }
}