using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.App.Queries.System;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 權限控制器。
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IPermissionQueryService permissionQueryService;

        /// <summary>
        /// 初始化 <see cref="PermissionsController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="commandService">命令服務。</param>
        /// <param name="permissionQueryService">權限查詢服務。</param>
        public PermissionsController(ICommandService commandService, IPermissionQueryService permissionQueryService)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.permissionQueryService = permissionQueryService ?? throw new ArgumentNullException(nameof(permissionQueryService));
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有權限。</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationOption option)
        {
            var permissions = await permissionQueryService.GetPermissionsAsync(option);
            Response.Headers.Add("X-Pagination", permissions.ItemCount.ToString());

            return Ok(permissions.Items);
        }

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="id">權限 ID。</param>
        /// <returns>權限。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await permissionQueryService.GetPermissionAsync(id);
            if (permission == default(Permission))
                return NotFound();

            return Ok(permission);
        }

        /// <summary>
        /// 新增權限。
        /// </summary>
        /// <param name="command">新增權限命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePermissionCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var permission = await commandService.ExecuteAsync<Permission>(command);

            return CreatedAtAction(nameof(Get), new { id = permission.PermissionId }, permission);
        }
    }
}