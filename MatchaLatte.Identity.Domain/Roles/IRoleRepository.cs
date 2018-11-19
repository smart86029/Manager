using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Identity.Domain.Roles
{
    /// <summary>
    /// 角色存放庫。
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>
        Task<ICollection<Role>> GetRolesAsync();

        /// <summary>
        /// 取得所有符合條件的角色。
        /// </summary>
        /// <param name="criteria">條件。</param>
        /// <returns>所有符合條件的角色。</returns>
        Task<ICollection<Role>> GetRolesAsync(Expression<Func<Role, bool>> criteria);

        /// <summary>
        /// 取得指定筆數的角色。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>指定筆數的角色。</returns>
        Task<ICollection<Role>> GetRolesAsync(int offset, int limit);

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        Task<Role> GetRoleAsync(Guid roleId);

        /// <summary>
        /// 取得所有角色的數量。
        /// </summary>
        /// <returns>所有角色的數量。</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// 加入角色。
        /// </summary>
        /// <param name="role">角色。</param>
        void Add(Role role);

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="role">角色。</param>
        void Update(Role role);
    }
}