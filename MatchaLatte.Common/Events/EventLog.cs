using System;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件日誌。
    /// </summary>
    public class EventLog
    {
        private Event @event;

        private EventLog()
        {
        }

        public EventLog(Event @event)
        {
            var eventType = @event.GetType();

            EventId = @event.Id;
            EventTypeNamespace = eventType.Namespace;
            EventTypeName = eventType.Name;
            EventContent = JsonUtility.Serialize(@event);
            CreatedOn = @event.CreatedOn;
            Event = @event;
        }

        /// <summary>
        /// 取得事件 ID。
        /// </summary>
        public Guid EventId { get; private set; }

        /// <summary>
        /// 取得事件類型命名空間。
        /// </summary>
        public string EventTypeNamespace { get; private set; }

        /// <summary>
        /// 取得事件類型名稱。
        /// </summary>
        public string EventTypeName { get; private set; }

        /// <summary>
        /// 取得事件內容。
        /// </summary>
        public string EventContent { get; private set; }

        /// <summary>
        /// 取得發布狀態。
        /// </summary>
        public PublishState PublishState { get; private set; } = PublishState.Waiting;

        /// <summary>
        /// 取得發布次數。
        /// </summary>
        public int PublishCount { get; private set; }

        /// <summary>
        /// 取得建立時間。
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得事件。
        /// </summary>
        public Event Event
        {
            get
            {
                if (@event == default)
                    @event = JsonUtility.Deserialize(EventContent, Type.GetType(EventTypeName)) as Event;

                return @event;
            }
            set
            {
                @event = value;
            }
        }

        /// <summary>
        /// 發布。
        /// </summary>
        public void Publish()
        {
            switch (PublishState)
            {
                case PublishState.Waiting:
                case PublishState.Failed:
                    PublishState = PublishState.InProgress;
                    PublishCount++;
                    break;

                case PublishState.InProgress:
                    PublishCount++;
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// 完成。
        /// </summary>
        public void Complete()
        {
            if (PublishState == PublishState.InProgress)
                PublishState = PublishState.Completed;
        }

        /// <summary>
        /// 失敗。
        /// </summary>
        public void Fail()
        {
            if (PublishState != PublishState.Completed)
                PublishState = PublishState.Failed;
        }
    }
}