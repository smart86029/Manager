using MatchaLatte.Catalog.Domain;

namespace MatchaLatte.Catalog.App.Stores
{
    public class PhoneDetail
    {
        public PhoneType PhoneType { get; set; }

        public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}