using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件匯流排。
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly string connectionString;
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 初始化 <see cref="EventBus"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        /// <param name="serviceProvider">服務提供者。</param>
        public EventBus(string connectionString, IServiceProvider serviceProvider)
        {
            this.connectionString = connectionString;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 發布。
        /// </summary>
        /// <param name="e">事件。</param>
        public async Task PublishAsync(Event @event)
        {
            using (var advancedBus = RabbitHutch.CreateBus(connectionString).Advanced)
            {
                var exchange = advancedBus.ExchangeDeclare("eventExchange", ExchangeType.Direct);
                var queue = advancedBus.QueueDeclare("event");
                var routingKey = "test";
                var binding = advancedBus.Bind(exchange, queue, routingKey, null);

                await advancedBus.PublishAsync(exchange, routingKey, false, new Message<string>(JsonUtility.Serialize(@event)));
            }
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
            var advancedBus = RabbitHutch.CreateBus(connectionString).Advanced;
            var exchange = advancedBus.ExchangeDeclare("eventExchange", ExchangeType.Direct);
            var queue = advancedBus.QueueDeclare("event");
            var routingKey = "test";
            var binding = advancedBus.Bind(exchange, queue, routingKey, null);
            var handler = serviceProvider.GetService(typeof(TEventHandler)) as IEventHandler<TEvent>;

            advancedBus.Consume(queue, (IMessage<string> message, MessageReceivedInfo info) => handler.HandleAsync(JsonUtility.Deserialize<TEvent>(message.Body)));
        }
    }
}