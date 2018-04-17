using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models.System;

namespace Manager.Services
{
    /// <summary>
    /// 角色服務。
    /// </summary>
    public class RoleService
    {
        private IUnitOfWork unitOfWork;
        private IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="RoleService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>符合的角色。</returns>
        public async Task<Role> GetRoleAsync(int id)
        {
            var role = await roleRepository.FindAsync(id);

            return role;
        }

        /// <summary>
        /// 取得角色，包含使用者。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>符合的角色。</returns>
        public async Task<Role> GetRoleIncludeUsersAsync(int id)
        {
            var role = await roleRepository.FirstOrDefaultAsync(r => r.RoleId == id);

            return role;
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>
        public async Task<ICollection<Role>> GetRolesAsync()
        {
            var roles = await roleRepository.ManyAsync(null);

            return roles.ToList();
        }

        /// <summary>
        /// 新增角色。
        /// </summary>
        /// <param name="role">要新增的角色。</param>
        /// <returns>新增成功傳回是，否則為否。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="role"/> 為 null。</exception>
        public async Task<bool> CreateAsync(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            roleRepository.Create(role);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="role">要更新的角色。</param>
        /// <param name="selectedUsers">使用者清單選擇的使用者。</param>
        /// <returns>更新成功傳回是，否則為否。</returns>
        /// <<exception cref="ArgumentNullException"><paramref name="role"/> 為 null。</exception>
        public async Task<bool> UpdateAsync(Role role, string[] selectedUsers)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            //await UpdateUsers(role, selectedUsers);
            roleRepository.Update(role);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 刪除角色。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>刪除成功傳回是，否則為否。 如果找不到符合的角色，則這個方法也會傳回否。</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var role = await roleRepository.FindAsync(id);
            if (role == null)
                return false;

            roleRepository.Delete(role);
            await unitOfWork.CommitAsync();

            return true;
        }

        ///// <summary>
        ///// 更新關聯使用者。
        ///// </summary>
        ///// <param name="role">角色。</param>
        ///// <param name="selectedUsers">使用者清單選擇的使用者。</param>
        ///// <exception cref="ArgumentNullException"></exception>
        //private async Task UpdateUsers(Role role, string[] selectedUsers)
        //{
        //    if (role == null)
        //        throw new ArgumentNullException(nameof(role));
        //    if (selectedUsers == null)
        //    {
        //        role.Users = new List<User>();
        //        return;
        //    }

        //    var users = await userRepository.ManyAsync(null);
        //    var currentUserIds = role.Users.Select(u => u.UserId);

        //    foreach (var user in users)
        //    {
        //        if (selectedUsers.Contains(user.UserId.ToString()))
        //        {
        //            if (!currentUserIds.Contains(user.UserId))
        //                role.Users.Add(user);
        //        }
        //        else
        //        {
        //            if (currentUserIds.Contains(user.UserId))
        //                role.Users.Remove(user);
        //        }
        //    }
        //}
    }
}