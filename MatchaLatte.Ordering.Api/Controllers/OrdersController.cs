using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.Api.Models;
using MatchaLatte.Ordering.App.Commands.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Ordering.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CurrentUser currentUser;
        private readonly ICommandService commandService;

        /// <summary>
        /// 初始化 <see cref="OrdersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="currentUser">當前使用者。</param>
        /// <param name="commandService">命令服務。</param>
        public OrdersController(CurrentUser currentUser, ICommandService commandService)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        }

        /// <summary>
        /// 取得訂單。
        /// </summary>
        /// <param name="id">訂單 ID。</param>
        /// <returns>訂單。</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            throw new NotImplementedException();

            //var group = await groupService.GetGroupAsync(id);
            //if (group == null)
            //    return NotFound();

            //return Ok(group);
        }

        /// <summary>
        /// 新增訂單。
        /// </summary>
        /// <param name="command">新增訂單查詢。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateOrderCommand command)
        {
            command.UserId = currentUser.UserId;
            var order = await commandService.ExecuteAsync(command);

            return CreatedAtAction(nameof(GetAsync), new { id = order.Id }, order);
        }
    }
}
