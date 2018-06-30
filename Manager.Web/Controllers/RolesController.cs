using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.App.Queries.System;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 角色控制器。
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IRoleQueryService roleQueryService;

        /// <summary>
        /// 初始化 <see cref="RolesController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="roleService">角色服務。</param>
        public RolesController(ICommandService commandService, IRoleQueryService roleQueryService)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.roleQueryService = roleQueryService ?? throw new ArgumentNullException(nameof(roleQueryService));
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <param name="query">分頁查詢。</param>
        /// <returns>所有角色。</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationOption option)
        {
            var roles = await roleQueryService.GetRolesAsync(option);
            Response.Headers.Add("X-Pagination", roles.ItemCount.ToString());

            return Ok(roles.Items);
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <returns>角色。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await roleQueryService.GetRoleAsync(id);
            if (role == default(Role))
                return NotFound();

            return Ok(role);
        }

        /// <summary>
        /// 新增角色。
        /// </summary>
        /// <param name="command">新增角色命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var role = await commandService.ExecuteAsync<Role>(command);

            return CreatedAtAction(nameof(Get), new { id = role.RoleId }, role);
        }

        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="id">角色 ID。</param>
        /// <param name="command">修改角色命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateRoleCommand command)
        {
            if (id != command.RoleId)
                return BadRequest();

            await commandService.ExecuteAsync<bool>(command);

            return NoContent();
        }

        ///// <summary>
        ///// 刪除角色。
        ///// </summary>
        ///// <param name="id">角色ID。</param>
        ///// <returns>204 NoContent。</returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType((int)HttpStatusCode.NoContent)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await roleService.DeleteAsync(id);

        //    return NoContent();
        //}
    }
}