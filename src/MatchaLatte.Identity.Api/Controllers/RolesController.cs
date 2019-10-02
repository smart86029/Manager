using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;
using MatchaLatte.Identity.App.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
    /// <summary>
    /// 角色控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;

        /// <summary>
        /// 初始化 <see cref="RolesController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="roleService">角色服務。</param>
        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        /// <summary>
        /// 取得角色的集合。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>角色的集合。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationOption option)
        {
            var roles = await roleService.GetRolesAsync(option);
            Response.Headers.Add("X-Total-Count", roles.ItemCount.ToString());

            return Ok(roles.Items);
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="id">角色 ID。</param>
        /// <returns>角色。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var role = await roleService.GetRoleAsync(id);
            if (role == default(RoleDetail))
                return NotFound();

            return Ok(role);
        }

        /// <summary>
        /// 取得新角色。
        /// </summary>
        /// <returns>新角色。</returns>
        [HttpGet("new")]
        public async Task<IActionResult> GetNewAsync()
        {
            var role = await roleService.GetNewRoleAsync();

            return Ok(role);
        }

        /// <summary>
        /// 建立角色。
        /// </summary>
        /// <param name="command">建立角色命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateRoleCommand command)
        {
            var role = await roleService.CreateRoleAsync(command);

            return CreatedAtAction("Get", new { id = role.Id }, role);
        }

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="id">角色 ID。</param>
        /// <param name="command">更新角色命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateRoleCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await roleService.UpdateRoleAsync(command);

            return NoContent();
        }
    }
}