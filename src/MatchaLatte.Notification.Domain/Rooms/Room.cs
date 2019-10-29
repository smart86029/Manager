using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.Notification.Domain.Rooms
{
    public class Room : AggregateRoot
    {
        private readonly List<Guid> memberIds = new List<Guid>();

        private Room()
        {
        }

        public Room(string name, IEnumerable<Guid> memberIds)
        {
            switch (memberIds.Count())
            {
                case var count when count < 2:
                    throw new DomainException("成員至少需要 2 個");

                case 2:
                    Type = RoomType.Personal;
                    break;

                default:
                    Type = RoomType.Group;
                    break;
            }

            Name = name.Trim();
            this.memberIds.AddRange(memberIds);
        }

        public string Name { get; private set; }

        public RoomType Type { get; private set; }
    }
}