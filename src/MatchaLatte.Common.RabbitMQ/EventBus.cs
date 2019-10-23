using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;
using MatchaLatte.Common.Events;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Common.RabbitMQ
{
    public class EventBus : Events.IEventBus, IDisposable
    {
        private readonly IAdvancedBus advancedBus;
        private readonly IExchange exchange;
        private readonly IQueue queue;
        private readonly IServiceProvider serviceProvider;
        private readonly Dictionary<string, Subscription> subscriptions = new Dictionary<string, Subscription>();

        /// <summary>
        /// 初始化 <see cref="EventBus"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        /// <param name="queueName">佇列名稱。</param>
        /// <param name="serviceProvider">服務提供者。</param>
        public EventBus(string connectionString, string queueName, IServiceProvider serviceProvider)
        {
            advancedBus = RabbitHutch.CreateBus(connectionString).Advanced;
            exchange = advancedBus.ExchangeDeclare("eventExchange", ExchangeType.Topic);
            queue = advancedBus.QueueDeclare(queueName);
            this.serviceProvider = serviceProvider;

            advancedBus.Consume(queue, async (byte[] body, MessageProperties properties, MessageReceivedInfo info) =>
            {
                if (subscriptions.TryGetValue(info.RoutingKey, out var subscription))
                {
                    var @event = JsonUtility.Deserialize(Encoding.UTF8.GetString(body), subscription.EventType);
                    var eventHandler = serviceProvider.GetService(subscription.EventHandlerType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(subscription.EventType);
                    if (eventHandler == default)
                        return;

                    await Task.Yield();
                    await (Task)concreteType.GetMethod("HandleAsync").Invoke(eventHandler, new object[] { @event });
                }
            });
        }

        public void Dispose()
        {
            advancedBus.Dispose();
        }

        /// <summary>
        /// 發布。
        /// </summary>
        /// <param name="@event">事件。</param>
        public async Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : Event
        {
            var routingKey = @event.GetType().Name;
            var properties = new MessageProperties();
            var body = Encoding.UTF8.GetBytes(JsonUtility.Serialize(@event));

            await advancedBus.PublishAsync(exchange, routingKey, false, properties, body);
        }

        /// <summary>
        /// 訂閱。
        /// </summary>
        /// <typeparam name="TEvent">事件類型。</typeparam>
        /// <typeparam name="TEventHandler">事件處理常式類型。</typeparam>
        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            var routingKey = typeof(TEvent).Name;

            advancedBus.Bind(exchange, queue, routingKey);
            subscriptions.Add(routingKey, new Subscription(typeof(TEvent), typeof(TEventHandler)));
        }

        public void Subscribe(Type eventType, Type eventHandlerType)
        {
            var routingKey = eventType.Name;

            advancedBus.Bind(exchange, queue, routingKey);
            subscriptions.Add(routingKey, new Subscription(eventType, eventHandlerType));
        }
    }
}