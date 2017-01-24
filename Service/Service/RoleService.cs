using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models;

namespace Manager.Service
{
    public class RoleService
    {
        private IUnitOfWork unitOfWork;
        private IRoleRepository roleRepository;

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <returns></returns>
        public async Task<Role> GetRoleAsync(int id)
        {
            var role = await roleRepository.FindAsync(id);
            return role;
        }

        /// <summary>
        /// 取得角色，包含使用者。
        /// </summary>
        /// <returns></returns>
        public async Task<Role> GetRoleIncludeUsersAsync(int id)
        {
            var role = await roleRepository.FirstOrDefaultAsync(r => r.RoleId == id, r => r.Users);

            return role;
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Role>> GetRolesAsync()
        {
            var roles = await roleRepository.ManyAsync(null);

            return roles.ToList();
        }

        /// <summary>
        /// 新增角色。
        /// </summary>
        /// <param name="user">要新增的角色。</param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
