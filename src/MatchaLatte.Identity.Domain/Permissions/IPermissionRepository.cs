﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Identity.Domain.Permissions
{
    /// <summary>
    /// 權限存放庫。
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <returns>所有權限。</returns>
        Task<ICollection<Permission>> GetPermissionsAsync();

        /// <summary>
        /// 取得所有符合條件的權限。
        /// </summary>
        /// <param name="criteria">條件。</param>
        /// <returns>所有符合條件的權限。</returns>
        Task<ICollection<Permission>> GetPermissionsAsync(Expression<Func<Permission, bool>> criteria);

        /// <summary>
        /// 取得指定筆數的權限。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>指定筆數的權限。</returns>
        Task<ICollection<Permission>> GetPermissionsAsync(int offset, int limit);

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        Task<Permission> GetPermissionAsync(Guid permissionId);

        /// <summary>
        /// 取得所有權限的數量。
        /// </summary>
        /// <returns>所有權限的數量。</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// 加入權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        void Add(Permission permission);

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        void Update(Permission permission);
    }
}