using MatchaLatte.Ordering.Domain;

namespace MatchaLatte.Ordering.App.ViewModels
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