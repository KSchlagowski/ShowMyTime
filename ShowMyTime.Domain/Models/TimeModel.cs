using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowMyTime.Domain.Models
{
    public class TimeModel
    {  
        public string TimeZone { get; set; }
        public string CurrentTime { get; set; }
        public string ErrorMessage { get; set; }
        public string AllTimeZones { get; set; }
    }
}