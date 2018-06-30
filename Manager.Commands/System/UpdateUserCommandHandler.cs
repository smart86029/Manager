using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, bool>
    {
        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="UpdateUserCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="userRepository">使用者存放庫。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public UpdateUserCommandHandler(ISystemUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<bool> HandleAsync(ICommand command)
        {
            var updateUserCommand = command as UpdateUserCommand ?? throw new NotSupportedException();
            var user = await userRepository.GetUserAsync(updateUserCommand.UserId);
            if (user == default(User))
                return false;

            user.UpdateUserName(updateUserCommand.UserName);
            if (!string.IsNullOrWhiteSpace(updateUserCommand.Password))
                user.UpdatePassword(updateUserCommand.Password);

            if (updateUserCommand.IsEnabled)
                user.Enable();
            else
                user.Disable();

            var roleIdsToAssign = updateUserCommand.Roles.Where(x => x.IsChecked).Select(x => x.RoleId)
                .Except(user.UserRoles.Select(x => x.RoleId));
            var rolesToAssign = await roleRepository.GetRolesAsync(r => roleIdsToAssign.Contains(r.RoleId));
            foreach (var role in rolesToAssign)
                user.AssignRole(role);

            var roleIdsToUnassign = user.UserRoles.Select(x => x.RoleId)
                .Except(updateUserCommand.Roles.Where(x => x.IsChecked).Select(x => x.RoleId));
            var rolesToUnassign = await roleRepository.GetRolesAsync(r => roleIdsToUnassign.Contains(r.RoleId));
            foreach (var role in rolesToUnassign)
                user.UnassignRole(role);

            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}