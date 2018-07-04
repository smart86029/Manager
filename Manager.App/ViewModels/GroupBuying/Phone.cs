using Manager.Domain.Models.Generic;

namespace Manager.App.ViewModels.GroupBuying
{
    public class Phone
    {
        public PhoneType PhoneType { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string BaseNumber { get; set; }
        public string Extension { get; set; }
    }
}