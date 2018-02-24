using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Manager.Common;
using Manager.Models;

namespace Manager.Service.Controllers
{
    /// <summary>
    /// 使用者控制器
    /// </summary>
    public class UsersController : ApiController
    {
        private UserService userService;

        /// <summary>
        /// 初始化 <see cref="UsersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userService">使用者服務。</param>
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 非同步取得所有使用者。
        /// </summary>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含所有使用者。</returns>
        public async Task<IHttpActionResult> Get()
        {
            var users = await userService.GetUsersAsync();

            return Ok(users);
        }

        /// <summary>
        /// 非同步取得使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含使用者。</returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await userService.GetUserByIdAsync(id);

            return Ok(user);
        }

        /// <summary>
        /// 非同步新增使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 201 Created。</returns>
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await userService.CreateAsync(user);

            return CreatedAtRoute(Constant.RouteName, new { id = user.UserId }, user);
        }

        /// <summary>
        /// 非同步修改使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <param name="user">使用者。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Put(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != user.UserId)
                return BadRequest();

            await userService.UpdateAsync(user);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 非同步刪除使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含 204 NoContent。</returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            await userService.DeleteAsync(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}