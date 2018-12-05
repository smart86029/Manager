using System;

namespace MatchaLatte.Ordering.App.Queries.Groups
{
    public class GroupSummary
    {
        public Guid GroupId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public StoreSummary Store { get; set; }
    }
}