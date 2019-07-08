using System;

namespace MatchaLatte.Catalog.App.Queries.Groups
{
    public class GroupSummary
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public StoreSummary Store { get; set; }
    }
}