using System;
using System.Threading.Tasks;
using Manager.Domain.Repositories.System;

namespace Manager.Data.Repositories.GroupBuying
{
    /// <summary>
    /// 團購工作單元。
    /// </summary>
    public class GroupBuyingUnitOfWork : IGroupBuyingUnitOfWork
    {
        private GroupBuyingContext context;

        /// <summary>
        /// 初始化 <see cref="GroupBuyingUnitOfWork"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">團購內容。</param>
        public GroupBuyingUnitOfWork(GroupBuyingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 提交認可。
        /// </summary>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> CommitAsync()
        {
            await context.SaveChangesAsync();

            return true;
        }
    }
}