using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand, App.ViewModels.System.Permission>
    {
        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// 初始化 <see cref="CreatePermissionCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="permissionRepository">權限存放庫。</param>
        public CreatePermissionCommandHandler(ISystemUnitOfWork unitOfWork, IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        public async Task<App.ViewModels.System.Permission> HandleAsync(ICommand command)
        {
            var createPermissionCommand = command as CreatePermissionCommand ?? throw new NotSupportedException();
            var permission = new Permission(createPermissionCommand.Name, createPermissionCommand.Description, createPermissionCommand.IsEnabled);

            permissionRepository.Add(permission);
            await unitOfWork.CommitAsync();

            var result = new App.ViewModels.System.Permission
            {
                PermissionId = permission.PermissionId,
                Name = permission.Name,
                Description = permission.Description,
                IsEnabled = permission.IsEnabled
            };

            return result;
        }
    }
}