using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.Common;
using Manager.Data;
using Manager.Models.System;
using Manager.ViewModels;
using Manager.ViewModels.Users;

namespace Manager.Services
{
    /// <summary>
    /// 使用者服務。
    /// </summary>
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="UserService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="userRepository">使用者存放庫。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// 取得所有使用者。
        /// </summary>
        /// <param name="query">分頁查詢。</param>
        /// <returns>所有使用者。</returns>
        public async Task<PaginationResult<UserViewModel>> GetUsersAsync(PaginationQuery query)
        {
            var specification = new PaginationSpecification<User> { PageIndex = query.PageIndex, PageSize = query.PageSize };
            var users = await userRepository.ManyAsync(specification);
            var count = await userRepository.CountAsync(null);
            var result = new PaginationResult<UserViewModel>
            {
                Items = users.Select(u => new UserViewModel
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    IsEnabled = u.IsEnabled
                }).ToList(),
                ItemCount = count
            };

            return result;
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="id">使用者 ID。</param>
        /// <returns>使用者。</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await userRepository.FindAsync(id);

            return user;
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="passwordHash">密碼雜湊。</param>
        /// <returns>使用者。</returns>
        public async Task<User> GetUserAsync(string userName, string passwordHash)
        {
            var user = await userRepository.SingleOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash);

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
            var user = await userRepository.SingleOrDefaultAsync(u => u.UserId == id, u => u.UserRoles);
            var result = new UserResult
            {
                UserId = user.UserId,
                UserName = user.UserName,
                IsEnabled = user.IsEnabled,
                Roles = roles.Select(r => new UserResult.Role
                {
                    RoleId = r.RoleId,
                    Name = r.Name,
                    IsChecked = user.UserRoles.Any(x => x.RoleId == r.RoleId)
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        public async Task<UserResult> GetNewUserAsync()
        {
            var roles = await roleRepository.ManyAsync(null);
            var result = new UserResult
            {
                Roles = roles.Select(r => new UserResult.Role
                {
                    RoleId = r.RoleId,
                    Name = r.Name
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="query">新增使用者查詢。</param>
        /// <returns>使用者。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="query"/> 為 null。</exception>
        public async Task<User> CreateAsync(CreateUserQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var roleIds = query.Roles.Where(x => x.IsChecked).Select(x => x.RoleId);
            var specification = new PaginationSpecification<Role> { Criteria = r => roleIds.Contains(r.RoleId) };
            var user = new User
            {
                UserName = query.UserName,
                PasswordHash = CryptographyUtility.Hash(query.Password),
                IsEnabled = query.IsEnabled,
                UserRoles = (await roleRepository.ManyAsync(specification)).Select(r => new UserRole { Role = r }).ToList()
            };

            userRepository.Create(user);
            await unitOfWork.CommitAsync();

            return user;
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="query">更新使用者查詢。</param>
        /// <returns>更新成功傳回是，否則為否。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="query"/> 為 null。</exception>
        public async Task<bool> UpdateAsync(UpdateUserQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var user = await userRepository.SingleOrDefaultAsync(u => u.UserId == query.UserId, u => u.UserRoles);
            if (user == null)
                return false;

            var roleIds = query.Roles.Where(x => x.IsChecked).Select(x => x.RoleId);
            user.UserName = query.UserName;
            if (!string.IsNullOrWhiteSpace(query.Password))
                user.PasswordHash = CryptographyUtility.Hash(query.Password);

            var specification = new PaginationSpecification<Role> { Criteria = r => roleIds.Contains(r.RoleId) };
            user.IsEnabled = query.IsEnabled;
            user.UserRoles = (await roleRepository.ManyAsync(specification)).Select(r => new UserRole { UserId = user.UserId, RoleId = r.RoleId }).ToList();
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