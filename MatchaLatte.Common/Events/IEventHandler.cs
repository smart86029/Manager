using System.Threading.Tasks;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件處理常式。
    /// </summary>
    /// <typeparam name="TEvent">事件類型。</typeparam>
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="event">事件。</param>
        /// <returns>工作。</returns>
        Task HandleAsync(Event @event);
    }
}