using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, bool>
    {
        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 初始化 <see cref="UpdateRoleCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        public UpdateRoleCommandHandler(ISystemUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<bool> HandleAsync(ICommand command)
        {
            var updateRoleCommand = command as UpdateRoleCommand ?? throw new NotSupportedException();
            var role = await roleRepository.GetRoleAsync(updateRoleCommand.RoleId);

            role.UpdateName(updateRoleCommand.Name);

            if (updateRoleCommand.IsEnabled)
                role.Enable();
            else
                role.Disable();

            roleRepository.Update(role);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}