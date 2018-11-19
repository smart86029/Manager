using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.Domain;

namespace MatchaLatte.Identity.Data
{
    /// <summary>
    /// 身分識別工作單元。
    /// </summary>
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private IdentityContext context;

        /// <summary>
        /// 初始化 <see cref="SystemUnitOfWork"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">身分識別內容。</param>
        public IdentityUnitOfWork(IdentityContext context)
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