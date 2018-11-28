namespace MatchaLatte.Ordering.App.Queries.Stores
{
    public class AddressDetail
    {
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; } = string.Empty;
    }
}