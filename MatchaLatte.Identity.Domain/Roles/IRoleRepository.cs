using System;
using System.Collections.Generic;
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
        /// 取得角色的集合。
        /// </summary>
        /// <returns>角色的集合。</returns>
        Task<ICollection<Role>> GetRolesAsync();

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        Task<Role> GetRoleAsync(Guid roleId);

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