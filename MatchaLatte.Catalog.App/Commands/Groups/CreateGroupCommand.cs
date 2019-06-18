using System;
using MatchaLatte.Catalog.App.Queries.Groups;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Catalog.App.Commands.Groups
{
    public class CreateGroupCommand : ICommand<GroupDetail>
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Remark { get; set; }

        public Guid CreatedBy { get; set; }

        public StoreDto Store { get; set; }
    }
}