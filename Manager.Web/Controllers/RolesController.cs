using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Manager.Common;
using Manager.Models;
using Manager.Services;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 角色控制器。
    /// </summary>
    public class RolesController : ApiController
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
        /// 非同步取得所有角色。
        /// </summary>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含所有角色。</returns>
        public async Task<IHttpActionResult> Get()
        {
            var roles = await roleService.GetRolesAsync();

            return Ok(roles);
        }

        /// <summary>
        /// 非同步取得角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含角色。</returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            var role = await roleService.GetRoleAsync(id);

            if (role == null)
                return NotFound();

            return Ok(role);
        }

        /// <summary>
        /// 非同步新增角色。
        /// </summary>
        /// <param name="role">角色。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 201 Created。</returns>
        public async Task<IHttpActionResult> Post([FromBody]Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await roleService.CreateAsync(role);

            return CreatedAtRoute(Constant.RouteName, new { id = role.RoleId }, role);
        }

        /// <summary>
        /// 非同步修改角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <param name="role">角色。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Put(int id, [FromBody]Role role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != role.RoleId)
                return BadRequest();

            await roleService.UpdateAsync(role, new string[0]);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 非同步刪除角色。
        /// </summary>
        /// <param name="id">角色ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            await roleService.DeleteAsync(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}