using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Commands.Permissions;
using MatchaLatte.Identity.App.Queries;
using MatchaLatte.Identity.App.Queries.Permissions;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.Domain;
using MatchaLatte.Identity.Domain.Permissions;

namespace MatchaLatte.Identity.Services
{
    /// <summary>
    /// 權限服務。
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IIdentityUnitOfWork unitOfWork;
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// 初始化 <see cref="RoleService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="permissionRepository">權限存放庫。</param>
        public PermissionService(IIdentityUnitOfWork unitOfWork, IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有權限。</returns>
        public async Task<PaginationResult<PermissionSummary>> GetPermissionsAsync(PaginationOption option)
        {
            var permissions = await permissionRepository.GetPermissionsAsync(option.Offset, option.Limit);
            var count = await permissionRepository.GetCountAsync();
            var result = new PaginationResult<PermissionSummary>
            {
                Items = permissions.Select(p => new PermissionSummary
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsEnabled = p.IsEnabled
                }).ToList(),
                ItemCount = count
            };

            return result;
        }

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        public async Task<PermissionDetail> GetPermissionAsync(Guid permissionId)
        {
            var permission = await permissionRepository.GetPermissionAsync(permissionId);
            var result = new PermissionDetail
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description,
                IsEnabled = permission.IsEnabled
            };

            return result;
        }

        /// <summary>
        /// 新增權限。
        /// </summary>
        /// <param name="option">新增權限命令。</param>
        /// <returns>權限。</returns>
        public async Task<PermissionDetail> CreatePermissionAsync(CreatePermissionCommand command)
        {
            var permission = new Permission(command.Name, command.Description, command.IsEnabled);

            permissionRepository.Add(permission);
            await unitOfWork.CommitAsync();

            var result = new PermissionDetail
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description,
                IsEnabled = permission.IsEnabled
            };

            return result;
        }

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="command">更新權限命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> UpdatePermissionAsync(UpdatePermissionCommand command)
        {
            var permission = await permissionRepository.GetPermissionAsync(command.Id);
            if (permission == default(Permission))
                return false;

            permission.UpdateName(command.Name);
            permission.UpdateDescription(command.Description);

            if (command.IsEnabled)
                permission.Enable();
            else
                permission.Disable();

            permissionRepository.Update(permission);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}