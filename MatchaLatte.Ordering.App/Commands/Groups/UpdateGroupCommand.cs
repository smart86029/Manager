using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.App.Commands.Groups
{
    public class UpdateGroupCommand : ICommand<bool>
    {
        public Guid GroupId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remark { get; set; }
    }
}