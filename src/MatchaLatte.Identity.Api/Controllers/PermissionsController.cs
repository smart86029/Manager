using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;
using MatchaLatte.Identity.App.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
    /// <summary>
    /// 權限控制器。
    /// </summary>
    [Authorize]
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
        /// 取得權限的集合。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>權限的集合。</returns>
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
        /// <param name="id">權限 ID。</param>
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
        /// 建立權限。
        /// </summary>
        /// <param name="command">建立權限命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreatePermissionCommand option)
        {
            var permission = await permissionService.CreatePermissionAsync(option);

            return CreatedAtAction("Get", new { id = permission.Id }, permission);
        }

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="id">權限 ID。</param>
        /// <param name="command">更新權限命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdatePermissionCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await permissionService.UpdatePermissionAsync(command);

            return NoContent();
        }
    }
}