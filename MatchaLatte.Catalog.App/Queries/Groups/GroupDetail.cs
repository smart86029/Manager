using System;

namespace MatchaLatte.Catalog.App.Queries.Groups
{
    public class GroupDetail
    {
        public Guid Id { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public string Remark { get; set; }

        public StoreDetail Store { get; set; }
    }
}