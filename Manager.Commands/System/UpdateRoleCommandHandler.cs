using System;
using System.Linq;
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
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// 初始化 <see cref="UpdateRoleCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        /// <param name="permissionRepository">權限存放庫。</param>
        public UpdateRoleCommandHandler(ISystemUnitOfWork unitOfWork, IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        public async Task<bool> HandleAsync(ICommand command)
        {
            var updateRoleCommand = command as UpdateRoleCommand ?? throw new NotSupportedException();
            var role = await roleRepository.GetRoleAsync(updateRoleCommand.RoleId);
            if (role == default(Role))
                return false;

            role.UpdateName(updateRoleCommand.Name);

            if (updateRoleCommand.IsEnabled)
                role.Enable();
            else
                role.Disable();

            var permissionIdsToAssign = updateRoleCommand.Permissions.Where(x => x.IsChecked).Select(x => x.PermissionId)
                .Except(role.RolePermissions.Select(x => x.PermissionId));
            var permissionsToAssign = await permissionRepository.GetPermissionsAsync(p => permissionIdsToAssign.Contains(p.PermissionId));
            foreach (var permission in permissionsToAssign)
                role.AssignPermission(permission);

            var permissionIdsToUnassign = role.RolePermissions.Select(x => x.PermissionId)
                .Except(updateRoleCommand.Permissions.Where(x => x.IsChecked).Select(x => x.PermissionId));
            var permissionsToUnassign = await permissionRepository.GetPermissionsAsync(p => permissionIdsToUnassign.Contains(p.PermissionId));
            foreach (var permission in permissionsToUnassign)
                role.UnassignPermission(permission);

            roleRepository.Update(role);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}