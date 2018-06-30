using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manager.Domain.Models.System;

namespace Manager.Domain.Repositories.System
{
    /// <summary>
    /// 角色存放庫介面。
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>
        Task<ICollection<Role>> GetRolesAsync(Expression<Func<Role, bool>> criteria);

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