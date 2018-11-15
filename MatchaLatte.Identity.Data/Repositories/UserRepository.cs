﻿using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Identity.Data.Repositories
{
    /// <summary>
    /// 使用者存放庫。
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext context;

        /// <summary>
        /// 初始化 <see cref="UserRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">系統內容。</param>
        public UserRepository(IdentityContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <returns>使用者。</returns>
        public async Task<User> GetUserAsync(Guid userId)
        {
            return await context.Set<User>().Include(u => u.UserRoles).SingleOrDefaultAsync(u => u.UserId == userId);
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="passwordHash">密碼雜湊。</param>
        /// <returns>使用者。</returns>
        public async Task<User> GetUserAsync(string userName, string passwordHash)
        {
            return await context.Set<User>().SingleOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash);
        }

        /// <summary>
        /// 加入使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        public void Add(User user)
        {
            context.Set<User>().Add(user);
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}