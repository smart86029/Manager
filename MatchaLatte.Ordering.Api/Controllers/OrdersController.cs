using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.Api.Models;
using MatchaLatte.Ordering.App.Commands.Orders;
using MatchaLatte.Ordering.App.Queries.Orders;
using MatchaLatte.Ordering.App.Services;
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
        private readonly IOrderQueryService orderQueryService;

        /// <summary>
        /// 初始化 <see cref="OrdersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="currentUser">當前使用者。</param>
        /// <param name="commandService">命令服務。</param>
        public OrdersController(CurrentUser currentUser, ICommandService commandService, IOrderQueryService orderQueryService)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.orderQueryService = orderQueryService ?? throw new ArgumentNullException(nameof(orderQueryService));
        }

        /// <summary>
        /// 取得所有訂單。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有訂單。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync(OrderOption option)
        {
            var orders = await orderQueryService.GetOrdersAsync(option);
            Response.Headers.Add("X-Total-Count", orders.ItemCount.ToString());

            return Ok(orders);
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