using System;
using MatchaLatte.Catalog.App.Queries.Groups;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Catalog.App.Commands.Groups
{
    public class CreateGroupCommand : ICommand<GroupDetail>
    {
        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public string Remark { get; set; }

        public Guid CreatedBy { get; set; }

        public StoreDto Store { get; set; }
    }
}