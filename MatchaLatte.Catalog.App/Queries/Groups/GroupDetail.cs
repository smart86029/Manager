using System;

namespace MatchaLatte.Catalog.App.Queries.Groups
{
    public class GroupDetail
    {
        public Guid GroupId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Remark { get; set; }

        public StoreDetail Store { get; set; }
    }
}