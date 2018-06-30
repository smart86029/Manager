using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, App.ViewModels.System.Role>
    {
        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="CreateRoleCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public CreateRoleCommandHandler(ISystemUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<App.ViewModels.System.Role> HandleAsync(ICommand command)
        {
            var createRoleCommand = command as CreateRoleCommand ?? throw new NotSupportedException();
            var role = new Role(createRoleCommand.Name, createRoleCommand.IsEnabled);

            roleRepository.Add(role);
            await unitOfWork.CommitAsync();

            var result = new App.ViewModels.System.Role
            {
                RoleId = role.RoleId,
                Name = role.Name,
                IsEnabled = role.IsEnabled
            };

            return result;
        }
    }
}