using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models;

namespace Manager.Service
{
    /// <summary>
    /// 使用者服務。
    /// </summary>
    public class UserService
    {
        private IUnitOfWork unitOfWork;
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="UserService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="userRepository">使用者倉儲。</param>
        /// <param name="roleRepository">角色倉儲。</param>
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>符合的使用者。</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await userRepository.FindAsync(id);

            return user;
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userName">指定的使用者名稱</param>
        /// <returns>符合的使用者。</returns>
        public async Task<User> GetUserByNameAsync(string userName)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserName == userName);

            return user;
        }

        /// <summary>
        /// 取得使用者，包含角色。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>符合的使用者。</returns>
        public async Task<User> GetUserIncludeRolesAsync(int id)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserId == id, u => u.Roles);

            return user;
        }

        /// <summary>
        /// 取得所有使用者。
        /// </summary>
        /// <returns>所有使用者。</returns>
        public async Task<ICollection<User>> GetUsersAsync()
        {
            var users = await userRepository.ManyAsync(null);

            return users.ToList();
        }

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="user">要新增的使用者。</param>
        /// <returns>新增成功傳回是，否則為否。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="user"/> 為 null。</exception>
        public async Task<bool> CreateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            userRepository.Create(user);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="user">要更新的使用者。</param>
        /// <param name="selectedRoles">角色清單選擇的角色。</param>
        /// <returns>更新成功傳回是，否則為否。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="user"/> 為 null。</exception>
        public async Task<bool> UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var originalUser = await userRepository.FirstOrDefaultAsync(u => u.UserId == user.UserId, u => u.Roles);
            if (originalUser == null)
            {
                return false;
            }

            originalUser.UserName = user.UserName;
            originalUser.IsEnabled = user.IsEnabled;

            var roles = await roleRepository.ManyAsync(null);
            var roleIdsToAdd = user.Roles.Select(r => r.RoleId).Except(originalUser.Roles.Select(r => r.RoleId));
            var roleIdsToRemove = originalUser.Roles.Select(r => r.RoleId).Except(user.Roles.Select(r => r.RoleId));

            foreach (var id in roleIdsToAdd)
            {
                originalUser.Roles.Add(roles.Single(r => r.RoleId == id));
            }
            foreach (var id in roleIdsToRemove)
            {
                originalUser.Roles.Remove(roles.Single(r => r.RoleId == id));
            }

            userRepository.Update(originalUser);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 刪除使用者。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>刪除成功傳回是，否則為否。 如果找不到符合的使用者，則這個方法也會傳回否。</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await userRepository.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            userRepository.Delete(user);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}