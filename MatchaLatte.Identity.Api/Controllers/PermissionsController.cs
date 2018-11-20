using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.Permission;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        /// <summary>
        /// 初始化 <see cref="PermissionsController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="permissionService">權限服務。</param>
        public PermissionsController(IPermissionService permissionService)
        {
            this.permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有權限。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationOption option)
        {
            var permissions = await permissionService.GetPermissionsAsync(option);
            Response.Headers.Add("X-Total-Count", permissions.ItemCount.ToString());

            return Ok(permissions.Items);
        }

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="id">權限ID。</param>
        /// <returns>權限。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var permission = await permissionService.GetPermissionAsync(id);
            if (permission == default(PermissionDetail))
                return NotFound();

            return Ok(permission);
        }

        /// <summary>
        /// 新增權限。
        /// </summary>
        /// <param name="command">新增權限命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreatePermissionOption option)
        {
            var permission = await permissionService.CreatePermissionAsync(option);

            return CreatedAtAction(nameof(GetAsync), new { id = permission.PermissionId }, permission);
        }

        /// <summary>
        /// 修改權限。
        /// </summary>
        /// <param name="id">權限ID。</param>
        /// <param name="option">更新權限查詢。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdatePermissionOption option)
        {
            if (id != option.PermissionId)
                return BadRequest();

            await permissionService.UpdatePermissionAsync(option);

            return NoContent();
        }
    }
}