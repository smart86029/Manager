using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Identity.Api.Controllers
{
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
        /// 取得所有使用者。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有使用者。</returns>
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
        /// <param name="id">使用者ID。</param>
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
        public async Task<IActionResult> GetNew()
        {
            var user = await userService.GetNewUserAsync();

            return Ok(user);
        }

        ///// <summary>
        ///// 新增使用者。
        ///// </summary>
        ///// <param name="command">新增使用者命令。</param>
        ///// <returns>201 Created。</returns>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        //{
        //    var user = await commandService.ExecuteAsync<User>(command);

        //    return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        //}

        /// <summary>
        /// 修改使用者。
        /// </summary>
        /// <param name="id">使用者ID。</param>
        /// <param name="option">更新使用者查詢。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]UpdateUserOption option)
        {
            if (id != option.UserId)
                return BadRequest();

            await userService.UpdateUserAsync(option);

            return NoContent();
        }
    }
}