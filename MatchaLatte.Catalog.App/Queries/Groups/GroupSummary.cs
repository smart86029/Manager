using System;

namespace MatchaLatte.Catalog.App.Queries.Groups
{
    public class GroupSummary
    {
        public Guid Id { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public StoreSummary Store { get; set; }
    }
}