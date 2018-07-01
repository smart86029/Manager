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
    /// 使用者控制器。
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IUserQueryService userQueryService;

        /// <summary>
        /// 初始化 <see cref="UsersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="commandService">命令服務。</param>
        /// <param name="userQueryService">使用者查詢服務。</param>
        public UsersController(ICommandService commandService, IUserQueryService userQueryService)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.userQueryService = userQueryService ?? throw new ArgumentNullException(nameof(userQueryService));
        }

        /// <summary>
        /// 取得所有使用者。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有使用者。</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationOption option)
        {
            var users = await userQueryService.GetUsersAsync(option);
            Response.Headers.Add("X-Pagination", users.ItemCount.ToString());

            await Task.Delay(3000);

            return Ok(users.Items);
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <returns>使用者。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userQueryService.GetUserAsync(id);
            if (user == default(User))
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            var user = await userQueryService.GetNewUserAsync();

            return Ok(user);
        }

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="command">新增使用者命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            var user = await commandService.ExecuteAsync<User>(command);

            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        /// <summary>
        /// 修改使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <param name="command">更新使用者查詢。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateUserCommand command)
        {
            if (id != command.UserId)
                return BadRequest();

            await commandService.ExecuteAsync<bool>(command);

            return NoContent();
        }

        ///// <summary>
        ///// 刪除使用者。
        ///// </summary>
        ///// <param name="id">使用者ID。</param>
        ///// <returns>204 NoContent。</returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType((int)HttpStatusCode.NoContent)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await userService.DeleteAsync(id);

        //    return NoContent();
        //}
    }
}