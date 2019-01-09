using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;
using EasyNetQ.FluentConfiguration;
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
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                var advancedBus = bus.Advanced;
                var exchange = advancedBus.ExchangeDeclare("MatchaLatte", ExchangeType.Fanout);
                await advancedBus.PublishAsync(exchange, string.Empty, false, new Message<Event>(@event));
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
            var handler = serviceProvider.GetService(typeof(TEventHandler)) as IEventHandler<TEvent>;

            var bus = RabbitHutch.CreateBus(connectionString);
            var advancedBus = bus.Advanced;
            var exchange = advancedBus.ExchangeDeclare("MatchaLatte", ExchangeType.Fanout);
            var queue = advancedBus.QueueDeclare();
            advancedBus.Bind(exchange, queue, string.Empty);
            //advancedBus.Consume(queue, new Action<EasyNetQ.Consumer.IConsumerConfiguration>()
            //bus.SubscribeAsync<TEvent>(string.Empty, async @event => await handler.HandleAsync(@event), config => config.WithTopic(""));
        }
    }
}