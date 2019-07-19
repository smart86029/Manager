using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Catalog.App.Commands.Groups
{
    public class UpdateGroupCommand : ICommand<bool>
    {
        public Guid id { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public string Remark { get; set; }
    }
}