using MatchaLatte.Notification.Domain.Messages;
using MongoDB.Bson.Serialization;

namespace MatchaLatte.Notification.Data.Mappings
{
    public class MessageMapping
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Message>(x =>
            {
                x.AutoMap();
            });
        }
    }
}
