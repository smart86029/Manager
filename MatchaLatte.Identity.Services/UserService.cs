using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.User;
using MatchaLatte.Identity.Domain.Users;

namespace MatchaLatte.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<PaginationResult<UserSummary>> GetUsersAsync(PaginationOption option)
        {
            var users = await userRepository.GetUsersAsync(option.PageIndex - 1, option.PageSize);
            var a = 1;
                throw new NotImplementedException();
            //var sql = $@"
            //    SELECT [UserId], [UserName], [IsEnabled]
            //    FROM [System].[User]
            //    ORDER BY [UserId]
            //    OFFSET @Skip ROWS
            //    FETCH NEXT @Take ROWS ONLY";
            //var sqlCount = $@"
            //    SELECT COUNT(*) FROM [System].[User]";
            //var param = new
            //{
            //    Skip = (option.PageIndex - 1) * option.PageSize,
            //    Take = option.PageSize
            //};
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