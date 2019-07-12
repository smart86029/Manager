namespace MatchaLatte.Common.Events
{
    public interface IEventLogRepository
    {
        void Add(EventLog eventLog);
    }
}