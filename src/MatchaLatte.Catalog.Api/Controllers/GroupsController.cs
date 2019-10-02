using System;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Api.Models;
using MatchaLatte.Catalog.App.Groups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Catalog.Api.Controllers
{
    /// <summary>
    /// 團控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly CurrentUser currentUser;
        private readonly IGroupService groupService;

        /// <summary>
        /// 初始化 <see cref="GroupsController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="currentUser">當前使用者。</param>
        /// <param name="groupService">團服務。</param>
        public GroupsController(CurrentUser currentUser, IGroupService groupService)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        /// <summary>
        /// 取得團的集合。
        /// </summary>
        /// <param name="option">團選項。</param>
        /// <returns>團的集合。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GroupOption option)
        {
            var groups = await groupService.GetGroupsAsync(option);
            Response.Headers.Add("X-Total-Count", groups.ItemCount.ToString());

            return Ok(groups.Items);
        }

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="id">團 ID。</param>
        /// <returns>團。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var group = await groupService.GetGroupAsync(id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        /// <summary>
        /// 建立團。
        /// </summary>
        /// <param name="command">建立團命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateGroupCommand command)
        {
            command.CreatedBy = currentUser.UserId;
            var group = await groupService.CreateGroupAsync(command);

            return CreatedAtAction("Get", new { id = group.Id }, group);
        }

        /// <summary>
        /// 更新團。
        /// </summary>
        /// <param name="id">團 ID。</param>
        /// <param name="command">更新團命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateGroupCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await groupService.UpdateGroupAsync(command);

            return NoContent();
        }
    }
}