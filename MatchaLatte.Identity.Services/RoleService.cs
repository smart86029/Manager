using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Commands.Roles;
using MatchaLatte.Identity.App.Queries;
using MatchaLatte.Identity.App.Queries.Roles;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.Domain;
using MatchaLatte.Identity.Domain.Permissions;
using MatchaLatte.Identity.Domain.Roles;

namespace MatchaLatte.Identity.Services
{
    /// <summary>
    /// 角色服務。
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IIdentityUnitOfWork unitOfWork;
        private readonly IRoleRepository roleRepository;
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// 初始化 <see cref="RoleService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="roleRepository">角色存放庫。</param>
        /// <param name="permissionRepository">權限存放庫。</param>
        public RoleService(IIdentityUnitOfWork unitOfWork, IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有角色。</returns>
        public async Task<PaginationResult<RoleSummary>> GetRolesAsync(PaginationOption option)
        {
            var roles = await roleRepository.GetRolesAsync(option.Offset, option.Limit);
            var count = await roleRepository.GetCountAsync();
            var result = new PaginationResult<RoleSummary>
            {
                Items = roles.Select(r => new RoleSummary
                {
                    RoleId = r.RoleId,
                    Name = r.Name,
                    IsEnabled = r.IsEnabled
                }).ToList(),
                ItemCount = count
            };

            return result;
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="userId">角色 ID。</param>
        /// <returns>角色。</returns>
        public async Task<RoleDetail> GetRoleAsync(Guid roleId)
        {
            var role = await roleRepository.GetRoleAsync(roleId);
            var permissions = await permissionRepository.GetPermissionsAsync();
            var result = new RoleDetail
            {
                RoleId = role.RoleId,
                Name = role.Name,
                IsEnabled = role.IsEnabled,
                Permissions = permissions.Select(p => new PermissionDetail
                {
                    PermissionId = p.PermissionId,
                    Name = p.Name,
                    IsChecked = role.RolePermissions.Any(x => x.PermissionId == p.PermissionId)
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 取得新角色。
        /// </summary>
        /// <returns>新角色。</returns>
        public async Task<RoleDetail> GetNewRoleAsync()
        {
            var permissions = await permissionRepository.GetPermissionsAsync();
            var result = new RoleDetail
            {
                Permissions = permissions.Select(p => new PermissionDetail
                {
                    PermissionId = p.PermissionId,
                    Name = p.Name
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 新增角色。
        /// </summary>
        /// <param name="command">新增角色命令。</param>
        /// <returns>角色。</returns>
        public async Task<RoleDetail> CreateRoleAsync(CreateRoleCommand command)
        {
            var role = new Role(command.Name, command.IsEnabled);
            var permissionIdsToAssign = command.Permissions.Where(x => x.IsChecked).Select(x => x.PermissionId);
            var permissionsToAssign = await permissionRepository.GetPermissionsAsync(p => permissionIdsToAssign.Contains(p.PermissionId));
            foreach (var permission in permissionsToAssign)
                role.AssignPermission(permission);

            roleRepository.Add(role);
            await unitOfWork.CommitAsync();

            var result = new RoleDetail
            {
                RoleId = role.RoleId,
                Name = role.Name,
                IsEnabled = role.IsEnabled
            };

            return result;
        }

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="command">更新角色命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> UpdateRoleAsync(UpdateRoleCommand command)
        {
            var role = await roleRepository.GetRoleAsync(command.RoleId);
            if (role == default(Role))
                return false;

            role.UpdateName(command.Name);

            if (command.IsEnabled)
                role.Enable();
            else
                role.Disable();

            var permissionIdsToAssign = command.Permissions.Where(x => x.IsChecked).Select(x => x.PermissionId)
                .Except(role.RolePermissions.Select(x => x.PermissionId));
            var permissionsToAssign = await permissionRepository.GetPermissionsAsync(r => permissionIdsToAssign.Contains(r.PermissionId));
            foreach (var permission in permissionsToAssign)
                role.AssignPermission(permission);

            var permissionIdsToUnassign = role.RolePermissions.Select(x => x.PermissionId)
                .Except(command.Permissions.Where(x => x.IsChecked).Select(x => x.PermissionId));
            var permissionsToUnassign = await permissionRepository.GetPermissionsAsync(r => permissionIdsToUnassign.Contains(r.PermissionId));
            foreach (var permission in permissionsToUnassign)
                role.UnassignPermission(permission);

            roleRepository.Update(role);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}