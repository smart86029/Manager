using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Commands.Users;
using MatchaLatte.Identity.App.Queries;
using MatchaLatte.Identity.App.Queries.Users;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.Domain;
using MatchaLatte.Identity.Domain.Roles;
using MatchaLatte.Identity.Domain.Users;

namespace MatchaLatte.Identity.Services
{
    /// <summary>
    /// 使用者服務。
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IIdentityUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="UserService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="userRepository">使用者存放庫。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public UserService(IIdentityUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        /// <summary>
        /// 取得所有使用者。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有使用者。</returns>
        public async Task<PaginationResult<UserSummary>> GetUsersAsync(PaginationOption option)
        {
            var users = await userRepository.GetUsersAsync(option.Offset, option.Limit);
            var count = await userRepository.GetCountAsync();
            var result = new PaginationResult<UserSummary>
            {
                Items = users.Select(u => new UserSummary
                {
                    Id = u.Id,
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
        /// <param name="userId">使用者 ID。</param>
        /// <returns>使用者。</returns>
        public async Task<UserDetail> GetUserAsync(Guid userId)
        {
            var user = await userRepository.GetUserAsync(userId);
            var roles = await roleRepository.GetRolesAsync();
            var result = new UserDetail
            {
                Id = user.Id,
                UserName = user.UserName,
                IsEnabled = user.IsEnabled,
                Roles = roles.Select(r => new RoleDetail
                {
                    Id = r.Id,
                    Name = r.Name,
                    IsChecked = user.UserRoles.Any(x => x.RoleId == r.Id)
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        public async Task<UserDetail> GetNewUserAsync()
        {
            var roles = await roleRepository.GetRolesAsync();
            var result = new UserDetail
            {
                Roles = roles.Select(r => new RoleDetail
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="command">新增使用者命令。</param>
        /// <returns>使用者。</returns>
        public async Task<UserDetail> CreateUserAsync(CreateUserCommand command)
        {
            var user = new User(command.UserName, command.Password, command.IsEnabled);
            var roleIdsToAssign = command.Roles.Where(x => x.IsChecked).Select(x => x.Id);
            var rolesToAssign = await roleRepository.GetRolesAsync(r => roleIdsToAssign.Contains(r.Id));
            foreach (var role in rolesToAssign)
                user.AssignRole(role);

            userRepository.Add(user);
            await unitOfWork.CommitAsync();

            var result = new UserDetail
            {
                Id = user.Id,
                UserName = user.UserName,
                IsEnabled = user.IsEnabled
            };

            return result;
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="command">更新使用者命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> UpdateUserAsync(UpdateUserCommand command)
        {
            var user = await userRepository.GetUserAsync(command.Id);
            if (user == default(User))
                return false;

            user.UpdateUserName(command.UserName);
            user.UpdatePassword(command.Password);

            if (command.IsEnabled)
                user.Enable();
            else
                user.Disable();

            var roleIdsToAssign = command.Roles.Where(x => x.IsChecked).Select(x => x.Id)
                .Except(user.UserRoles.Select(x => x.RoleId));
            var rolesToAssign = await roleRepository.GetRolesAsync(r => roleIdsToAssign.Contains(r.Id));
            foreach (var role in rolesToAssign)
                user.AssignRole(role);

            var roleIdsToUnassign = user.UserRoles.Select(x => x.RoleId)
                .Except(command.Roles.Where(x => x.IsChecked).Select(x => x.Id));
            var rolesToUnassign = await roleRepository.GetRolesAsync(r => roleIdsToUnassign.Contains(r.Id));
            foreach (var role in rolesToUnassign)
                user.UnassignRole(role);

            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}