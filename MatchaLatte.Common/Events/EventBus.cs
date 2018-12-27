using System;
using System.Threading.Tasks;
using EasyNetQ;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件匯流排。
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly string connectionString;

        /// <summary>
        /// 初始化 <see cref="EventBus"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public EventBus(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 發布。
        /// </summary>
        /// <param name="e">事件。</param>
        public async Task PublishAsync(Event e)
        {
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                await bus.PublishAsync(e);
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
            throw new NotImplementedException();
        }
    }
}