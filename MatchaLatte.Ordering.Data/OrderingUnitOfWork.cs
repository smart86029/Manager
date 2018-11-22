using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.Domain;

namespace MatchaLatte.Ordering.Data
{
    /// <summary>
    /// 訂購工作單元。
    /// </summary>
    internal class OrderingUnitOfWork : IOrderingUnitOfWork
    {
        private OrderingContext context;

        /// <summary>
        /// 初始化 <see cref="OrderingUnitOfWork"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">訂購內容。</param>
        public OrderingUnitOfWork(OrderingContext context)
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