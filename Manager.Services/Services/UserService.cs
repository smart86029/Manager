using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models;
using Manager.ViewModels.Users;

namespace Manager.Services
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
        public async Task<User> GetUserAsync(string userName, string passwordHash)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash, u => u.Roles);

            return user;
        }

        /// <summary>
        /// 取得使用者，包含角色。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>符合的使用者。</returns>
        public async Task<UserResult> GetUserIncludeRolesAsync(int id)
        {
            var roles = await roleRepository.ManyAsync(null);
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserId == id, u => u.Roles);
            var result = new UserResult
            {
                UserId = user.UserId,
                UserName = user.UserName,
                IsEnabled = user.IsEnabled,
                Roles = roles.Select(r => new UserResult.Role
                {
                    RoleId = r.RoleId,
                    Name = r.Name,
                    IsChecked = user.Roles.Contains(r)
                }).ToList()
            };

            return result;
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
                throw new ArgumentNullException(nameof(user));

            userRepository.Create(user);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="query">更新使用者查詢。</param>
        /// <returns>更新成功傳回是，否則為否。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="query"/> 為 null。</exception>
        public async Task<bool> UpdateAsync(PutUserQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var user = await userRepository.FirstOrDefaultAsync(u => u.UserId == query.UserId, u => u.Roles);
            if (user == null)
                return false;

            var roleIds = query.Roles.Where(x => x.IsChecked).Select(x => x.RoleId);
            user.UserName = query.UserName;
            user.IsEnabled = query.IsEnabled;
            user.Roles = (await roleRepository.ManyAsync(r => roleIds.Contains(r.RoleId))).ToList();
            userRepository.Update(user);
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
                return false;

            userRepository.Delete(user);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}