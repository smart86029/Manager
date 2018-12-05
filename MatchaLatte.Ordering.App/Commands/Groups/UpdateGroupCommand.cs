using System;
using System.Collections.Generic;
using System.Text;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.App.Commands.Groups
{
    public class UpdateGroupCommand : ICommand<bool>
    {
        public Guid GroupId { get; set; }
    }
}
