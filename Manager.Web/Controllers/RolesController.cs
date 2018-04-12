using System.Threading.Tasks;
using Manager.Common;
using Manager.Models.System;
using Manager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 角色控制器。
    /// </summary>
    //[JwtAuthorize]
    [Authorize]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private RoleService roleService;

        /// <summary>
        /// 初始化 <see cref="RolesController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="roleService">角色服務。</param>
        public RolesController(RoleService roleService)
        {
            this.roleService = roleService;
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await roleService.GetRolesAsync();

            return Ok(roles);
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <returns>角色。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await roleService.GetRoleAsync(id);

            if (role == null)
                return NotFound();

            return Ok(role);
        }

        /// <summary>
        /// 新增角色。
        /// </summary>
        /// <param name="role">角色。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await roleService.CreateAsync(role);

            return CreatedAtRoute(Constant.RouteName, new { id = role.RoleId }, role);
        }

        /// <summary>
        /// 修改角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <param name="role">角色。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != role.RoleId)
                return BadRequest();

            await roleService.UpdateAsync(role, new string[0]);

            return NoContent();
        }

        /// <summary>
        /// 刪除角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <returns>204 NoContent。</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await roleService.DeleteAsync(id);

            return NoContent();
        }
    }
}