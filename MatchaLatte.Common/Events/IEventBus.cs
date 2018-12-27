﻿using System.Threading.Tasks;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件匯流排。
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// 發布。
        /// </summary>
        /// <param name="e">事件。</param>
        Task PublishAsync(Event e);

        /// <summary>
        /// 訂閱。
        /// </summary>
        /// <typeparam name="TEvent">事件類型。</typeparam>
        /// <typeparam name="TEventHandler">事件處理常式類型。</typeparam>
        void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;
    }
}