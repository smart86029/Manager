using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        //private readonly PermissionService permissionService;

        ///// <summary>
        ///// 初始化 <see cref="PermissionsController"/> 類別的新執行個體。
        ///// </summary>
        ///// <param name="permissionService">權限服務。</param>
        //public PermissionsController(PermissionService permissionService)
        //{
        //    this.permissionService = permissionService;
        //}

        ///// <summary>
        ///// 取得所有權限。
        ///// </summary>
        ///// <param name="query">分頁查詢。</param>
        ///// <returns>所有權限。</returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(ICollection<PermissionViewModel>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> Get([FromQuery] PaginationQuery query)
        //{
        //    var permissions = await permissionService.GetPermissionsAsync(query);
        //    Response.Headers.Add("X-Pagination", permissions.ItemCount.ToString());

        //    return Ok(permissions.Items);
        //}

        ///// <summary>
        ///// 取得權限。
        ///// </summary>
        ///// <param name="id">權限 ID。</param>
        ///// <returns>權限。</returns>
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var permission = await permissionService.GetRoleAsync(id);

        //    if (permission == null)
        //        return NotFound();

        //    return Ok(permission);
        //}
    }
}