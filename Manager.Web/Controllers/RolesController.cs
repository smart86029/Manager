using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 角色控制器。
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        //private readonly RoleService roleService;

        ///// <summary>
        ///// 初始化 <see cref="RolesController"/> 類別的新執行個體。
        ///// </summary>
        ///// <param name="roleService">角色服務。</param>
        //public RolesController(RoleService roleService)
        //{
        //    this.roleService = roleService;
        //}

        ///// <summary>
        ///// 取得所有角色。
        ///// </summary>
        ///// <param name="query">分頁查詢。</param>
        ///// <returns>所有角色。</returns>
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] PaginationQuery query)
        //{
        //    var roles = await roleService.GetRolesAsync(query);
        //    Response.Headers.Add("X-Pagination", roles.ItemCount.ToString());

        //    return Ok(roles.Items);
        //}

        ///// <summary>
        ///// 取得角色。
        ///// </summary>
        ///// <param name="id">角色ID。</param>
        ///// <returns>角色。</returns>
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var role = await roleService.GetRoleAsync(id);

        //    if (role == null)
        //        return NotFound();

        //    return Ok(role);
        //}

        ///// <summary>
        ///// 新增角色。
        ///// </summary>
        ///// <param name="role">角色。</param>
        ///// <returns>201 Created。</returns>
        ///// <response code="201">Returns the newly-created item</response>
        //[HttpPost]
        //[ProducesResponseType(typeof(Role), (int)HttpStatusCode.Created)]
        //public async Task<IActionResult> Post([FromBody]Role role)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    await roleService.CreateAsync(role);

        //    return CreatedAtRoute(Constant.RouteName, new { id = role.RoleId }, role);
        //}

        ///// <summary>
        ///// 修改角色。
        ///// </summary>
        ///// <param name="id">角色ID。</param>
        ///// <param name="role">角色。</param>
        ///// <returns>204 NoContent。</returns>
        //[HttpPut("{id}")]
        //[ProducesResponseType((int)HttpStatusCode.NoContent)]
        //public async Task<IActionResult> Put(int id, [FromBody]Role role)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    if (id != role.RoleId)
        //        return BadRequest();

        //    await roleService.UpdateAsync(role, new string[0]);

        //    return NoContent();
        //}

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