using System;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.Data.Repositories
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly CatalogContext context;

        /// <summary>
        /// 初始化 <see cref="EventLogRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">目錄內容。</param>
        public EventLogRepository(CatalogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(EventLog eventLog)
        {
            context.Set<EventLog>().Add(eventLog);
        }
    }
}