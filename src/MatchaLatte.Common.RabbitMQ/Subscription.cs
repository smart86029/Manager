using System;

namespace MatchaLatte.Common.RabbitMQ
{
    internal class Subscription
    {
        internal Subscription(Type eventType, Type eventHandlerType)
        {
            EventType = eventType;
            EventHandlerType = eventHandlerType;
        }

        public Type EventType { get; private set; }

        public Type EventHandlerType { get; private set; }
    }
}