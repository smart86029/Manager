using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class UpdatePermissionCommandHandler : ICommandHandler<UpdatePermissionCommand, bool>
    {
        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// 初始化 <see cref="UpdatePermissionCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="permissionRepository">權限存放庫。</param>
        public UpdatePermissionCommandHandler(ISystemUnitOfWork unitOfWork, IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        public async Task<bool> HandleAsync(ICommand command)
        {
            var updatePermissionCommand = command as UpdatePermissionCommand ?? throw new NotSupportedException();
            var permission = await permissionRepository.GetPermissionAsync(updatePermissionCommand.PermissionId);
            if (permission == default(Permission))
                return false;

            permission.UpdateName(updatePermissionCommand.Name);
            permission.UpdateDescription(updatePermissionCommand.Description);

            if (updatePermissionCommand.IsEnabled)
                permission.Enable();
            else
                permission.Disable();

            permissionRepository.Update(permission);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}