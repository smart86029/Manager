﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Identity.Domain.Users
{
    /// <summary>
    /// 使用者存放庫。
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 取得使用者的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>使用者的集合。</returns>
        Task<ICollection<User>> GetUsersAsync(int offset, int limit);

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <returns>使用者。</returns>
        Task<User> GetUserAsync(Guid userId);

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="passwordHash">密碼雜湊。</param>
        /// <returns>使用者。</returns>
        Task<User> GetUserAsync(string userName, string passwordHash);

        /// <summary>
        /// 取得所有使用者的數量。
        /// </summary>
        /// <returns>所有使用者的數量。</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// 加入使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        void Add(User user);

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        void Update(User user);
    }
}