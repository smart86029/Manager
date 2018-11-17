using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.User;
using MatchaLatte.Identity.Domain.Roles;
using MatchaLatte.Identity.Domain.Users;

namespace MatchaLatte.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<PaginationResult<UserSummary>> GetUsersAsync(PaginationOption option)
        {
            var users = await userRepository.GetUsersAsync(option.Offset, option.Limit);
            var count = await userRepository.GetCountAsync();
            var result = new PaginationResult<UserSummary>
            {
                Items = users.Select(u => new UserSummary
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    IsEnabled = u.IsEnabled
                }).ToList(),
                ItemCount = count
            };

            return result;
        }

        public async Task<UserDetail> GetUserAsync(Guid userId)
        {
            var user = await userRepository.GetUserAsync(userId);
            var roles = await roleRepository.GetRolesAsync();
            var result = new UserDetail
            {
                UserId = user.UserId,
                UserName = user.UserName,
                IsEnabled = user.IsEnabled,
                Roles = roles.Select(r => new RoleDetail
                {
                    RoleId = r.RoleId,
                    Name = r.Name,
                    IsChecked = user.UserRoles.Any(x => x.RoleId == r.RoleId)
                }).ToList()
            };

            return result;
        }

        public async Task<UserDetail> GetNewUserAsync()
        {
            var roles = await roleRepository.GetRolesAsync();
            var result = new UserDetail
            {
                Roles = roles.Select(r => new RoleDetail
                {
                    RoleId = r.RoleId,
                    Name = r.Name
                }).ToList()
            };

            return result;
        }
    }
}