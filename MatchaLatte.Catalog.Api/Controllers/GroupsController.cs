using System;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Api.Models;
using MatchaLatte.Catalog.App.Commands.Groups;
using MatchaLatte.Catalog.App.Queries.Groups;
using MatchaLatte.Catalog.App.Services;
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
        /// <param name="groupService">團查詢服務。</param>
        public GroupsController(CurrentUser currentUser, IGroupService groupService)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        /// <summary>
        /// 取得所有團。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有團。</returns>
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
        /// 新增團。
        /// </summary>
        /// <param name="command">新增團查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateGroupCommand command)
        {
            command.CreatedBy = currentUser.UserId;
            var group = await groupService.CreateGroupAsync(command);

            return CreatedAtAction(nameof(GetAsync), new { id = group.GroupId }, group);
        }

        /// <summary>
        /// 修改團。
        /// </summary>
        /// <param name="id">團ID。</param>
        /// <param name="command">修改團命令。</param>
        /// <returns>204 NoContent。</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateGroupCommand command)
        {
            if (id != command.GroupId)
                return BadRequest();

            await groupService.UpdateGroupAsync(command);

            return NoContent();
        }
    }
}