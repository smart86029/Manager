using System;
using System.Collections.Generic;

namespace MatchaLatte.Notification.App.Rooms
{
    public class CreateRoomCommand
    {
        public List<Guid> MemberIds { get; set; }
    }
}