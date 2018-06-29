using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, App.ViewModels.System.User>
    {
        private const int ExpireMinutes = 120;

        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="CreateUserCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="userRepository">使用者存放庫。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public CreateUserCommandHandler(ISystemUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<App.ViewModels.System.User> HandleAsync(ICommand command)
        {
            var createUserCommand = command as CreateUserCommand ?? throw new NotSupportedException();
            var roleIds = createUserCommand.Roles.Where(x => x.IsChecked).Select(x => x.RoleId).ToList();
            var roles = await roleRepository.GetRolesAsync(r => roleIds.Contains(r.RoleId));
            var user = new User(createUserCommand.UserName, createUserCommand.Password, createUserCommand.IsEnabled, 0);

            foreach (var role in roles)
                user.AddUserRole(role);

            userRepository.Add(user);
            await unitOfWork.CommitAsync();

            var result = new App.ViewModels.System.User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                IsEnabled = user.IsEnabled
            };

            return result;
        }
    }
}