using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models;

namespace Manager.Service
{
    public class UserService
    {
        private IUnitOfWork unitOfWork;
        private IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await userRepository.FindAsync(id);
            return user;
        }

        public async Task<User> GetByNameAsync(string userName)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserName == userName);

            return user;
        }

        /// <summary>
        /// 取得使用者，包含角色。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns></returns>
        public async Task<User> GetUserIncludeRolesAsync(int id)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserId == id, u => u.Roles);

            return user;
        }

        ///// <summary>
        ///// 取得所有使用者。
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ICollection<User>> GetUsersAsync()
        //{
        //    var users = userRepository.ManyAsync(null);

        //    return users.ToList();
        //}

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="user">要新增的使用者。</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(User user)
        {
            userRepository.Create(user);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="user">要更新的使用者。</param>
        /// <param name="selectedRoles">角色清單選擇的角色。</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(User user, string[] selectedRoles)
        {
            //await UpdateRoles(user, selectedRoles);
            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 刪除使用者。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await userRepository.FindAsync(id);
            if (user == null)
                return false;

            userRepository.Delete(user);
            await unitOfWork.CommitAsync();

            return true;
        }

        ///// <summary>
        ///// 更新關聯角色。
        ///// </summary>
        ///// <param name="user">使用者。</param>
        ///// <param name="selectedRoles">角色清單選擇的角色。</param>
        ///// <exception cref="ArgumentNullException"></exception>
        //private async Task UpdateRoles(User user, string[] selectedRoles)
        //{
        //    if (user == null)
        //        throw new ArgumentNullException(nameof(user));
        //    if (selectedRoles == null)
        //    {
        //        user.Roles = new List<Role>();
        //        return;
        //    }

        //    var roles = await unitOfWork.RoleRepository.ManyAsync(null);
        //    var currentRoleIds = user.Roles.Select(r => r.RoleId);

        //    foreach (var role in roles)
        //    {
        //        if (selectedRoles.Contains(role.RoleId.ToString()))
        //        {
        //            if (!currentRoleIds.Contains(role.RoleId))
        //                user.Roles.Add(role);
        //        }
        //        else
        //        {
        //            if (currentRoleIds.Contains(role.RoleId))
        //                user.Roles.Remove(role);
        //        }
        //    }
        //}
    }
}
