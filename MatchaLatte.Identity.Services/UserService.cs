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

        public Task<UserDetail> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetail> GetNewUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}