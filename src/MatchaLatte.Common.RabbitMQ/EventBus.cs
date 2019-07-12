using System;
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
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 初始化 <see cref="EventBus"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        /// <param name="serviceProvider">服務提供者。</param>
        public EventBus(string connectionString, IServiceProvider serviceProvider)
        {
            advancedBus = RabbitHutch.CreateBus(connectionString).Advanced;
            this.serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            advancedBus.Dispose();
        }

        /// <summary>
        /// 發布。
        /// </summary>
        /// <param name="@event">事件。</param>
        public async Task PublishAsync(Event @event)
        {
            var exchange = advancedBus.ExchangeDeclare("eventExchange", ExchangeType.Direct);
            var queue = advancedBus.QueueDeclare("event");
            var routingKey = @event.GetType().Name;
            advancedBus.Bind(exchange, queue, routingKey);

            await advancedBus.PublishAsync(exchange, routingKey, false, new Message<string>(JsonUtility.Serialize(@event)));
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
            var exchange = advancedBus.ExchangeDeclare("eventExchange", ExchangeType.Direct);
            var queue = advancedBus.QueueDeclare("event");
            var routingKey = typeof(TEvent).Name;
            advancedBus.Bind(exchange, queue, routingKey);

            var handler = serviceProvider.GetService(typeof(TEventHandler)) as IEventHandler<TEvent>;
            advancedBus.Consume(queue, (IMessage<string> message, MessageReceivedInfo info) => handler.HandleAsync(JsonUtility.Deserialize<TEvent>(message.Body)));
        }
    }
}