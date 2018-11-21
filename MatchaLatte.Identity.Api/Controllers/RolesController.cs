using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.Role;
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
        /// 取得所有角色。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有角色。</returns>
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
        /// <param name="id">角色ID。</param>
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
        /// 新增角色。
        /// </summary>
        /// <param name="command">新增角色選項。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateRoleOption option)
        {
            var role = await roleService.CreateRoleAsync(option);

            return CreatedAtAction(nameof(GetAsync), new { id = role.RoleId }, role);
        }

        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <param name="option">更新角色選項。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateRoleOption option)
        {
            if (id != option.RoleId)
                return BadRequest();

            await roleService.UpdateRoleAsync(option);

            return NoContent();
        }
    }
}