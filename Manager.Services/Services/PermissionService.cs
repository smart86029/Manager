using System.Linq;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models.System;
using Manager.ViewModels;
using Manager.ViewModels.Permissions;

namespace Manager.Services
{
    /// <summary>
    /// 權限服務。
    /// </summary>
    public class PermissionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// 初始化 <see cref="PermissionService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="roleRepository">權限存放庫。</param>
        public PermissionService(IUnitOfWork unitOfWork, IPermissionRepository permissionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.permissionRepository = permissionRepository;
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="query">分頁查詢。</param>
        /// <returns>所有權限。</returns>
        public async Task<PaginationResult<PermissionViewModel>> GetPermissionsAsync(PaginationQuery query)
        {
            var specification = new PaginationSpecification<Permission> { PageIndex = query.PageIndex, PageSize = query.PageSize };
            var permissions = await permissionRepository.ManyAsync(specification);
            var count = await permissionRepository.CountAsync(null);
            var result = new PaginationResult<PermissionViewModel>
            {
                Items = permissions.Select(p => new PermissionViewModel
                {
                    PermissionId = p.PermissionId,
                    Name = p.Name,
                    IsEnabled = p.IsEnabled
                }).ToList(),
                ItemCount = count
            };

            return result;
        }
    }
}