using System;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Queries.Groups;

namespace MatchaLatte.Ordering.App.Commands.Groups
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