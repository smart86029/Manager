using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;
using MatchaLatte.Identity.App.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
    /// <summary>
    /// 使用者控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        /// <summary>
        /// 初始化 <see cref="UsersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userService">使用者服務。</param>
        public UsersController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// 取得使用者的集合。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>使用者的集合。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationOption option)
        {
            var users = await userService.GetUsersAsync(option);
            Response.Headers.Add("X-Total-Count", users.ItemCount.ToString());

            return Ok(users.Items);
        }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="id">使用者 ID。</param>
        /// <returns>使用者。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var user = await userService.GetUserAsync(id);
            if (user == default(UserDetail))
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        [HttpGet("new")]
        public async Task<IActionResult> GetNewAsync()
        {
            var user = await userService.GetNewUserAsync();

            return Ok(user);
        }

        /// <summary>
        /// 建立使用者。
        /// </summary>
        /// <param name="command">建立使用者命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserCommand command)
        {
            var user = await userService.CreateUserAsync(command);

            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="id">使用者 ID。</param>
        /// <param name="command">更新使用者命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await userService.UpdateUserAsync(command);

            return NoContent();
        }
    }
}