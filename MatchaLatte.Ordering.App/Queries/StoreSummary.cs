using System;

namespace MatchaLatte.Ordering.App.Queries
{
    public class StoreSummary
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}