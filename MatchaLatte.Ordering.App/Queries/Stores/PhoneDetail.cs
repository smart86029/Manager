using MatchaLatte.Ordering.Domain;

namespace MatchaLatte.Ordering.App.Queries.Stores
{
    public class PhoneDetail
    {
        public PhoneType PhoneType { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}