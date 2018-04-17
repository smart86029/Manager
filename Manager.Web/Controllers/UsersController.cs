using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Manager.Common;
using Manager.Models.System;
using Manager.Services;
using Manager.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 使用者控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
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
        /// 取得所有使用者。
        /// </summary>
        /// <returns>所有使用者。</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<User>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var users = await userService.GetUsersAsync();

            return Ok(users);
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>使用者。</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userService.GetUserIncludeRolesAsync(id);

            return Ok(user);
        }

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        [HttpGet("New")]
        [ProducesResponseType(typeof(UserResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNew()
        {
            var user = await userService.GetNewUserAsync();

            return Ok(user);
        }

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="query">新增使用者查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]CreateUserQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userService.CreateAsync(query);

            return CreatedAtRoute(Constant.RouteName, new { id = user.UserId }, query);
        }

        /// <summary>
        /// 修改使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <param name="query">更新使用者查詢。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateUserQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != query.UserId)
                return BadRequest();

            await userService.UpdateAsync(query);

            return NoContent();
        }

        /// <summary>
        /// 刪除使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>204 NoContent。</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await userService.DeleteAsync(id);

            return NoContent();
        }
    }
}