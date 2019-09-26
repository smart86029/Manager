using System;

namespace MatchaLatte.Catalog.App.Stores
{
    public class StoreSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LogoUri { get; set; }
    }
}