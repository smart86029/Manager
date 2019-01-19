using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Groups;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Ordering.Api.Controllers
{
    /// <summary>
    /// 團控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IGroupQueryService groupQueryService;

        /// <summary>
        /// 初始化 <see cref="GroupsController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="commandService">命令服務。</param>
        /// <param name="userQueryService">使用者查詢服務。</param>
        public GroupsController(ICommandService commandService, IGroupQueryService groupQueryService)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.groupQueryService = groupQueryService ?? throw new ArgumentNullException(nameof(groupQueryService));
        }

        /// <summary>
        /// 取得所有團。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有團。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationOption option)
        {
            var groups = await groupQueryService.GetGroupsAsync(option);
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
            var group = await groupQueryService.GetGroupAsync(id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        /// <summary>
        /// 取得新團。
        /// </summary>
        /// <returns>新團。</returns>
        [HttpGet("new")]
        public async Task<IActionResult> GetNewAsync(Guid storeId)
        {
            var group = await groupQueryService.GetNewGroupAsync(storeId);

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
            var group = await commandService.ExecuteAsync(command);

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

            await commandService.ExecuteAsync(command);

            return NoContent();
        }
    }
}