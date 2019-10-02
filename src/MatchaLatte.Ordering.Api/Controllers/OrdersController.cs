using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.Api.Models;
using MatchaLatte.Ordering.App.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchaLatte.Ordering.Api.Controllers
{
    /// <summary>
    /// 訂單控制器。
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CurrentUser currentUser;
        private readonly IOrderService orderService;

        /// <summary>
        /// 初始化 <see cref="OrdersController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="currentUser">當前使用者。</param>
        /// <param name="orderService">命令服務。</param>
        public OrdersController(CurrentUser currentUser, IOrderService orderService)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        /// <summary>
        /// 取得訂單的集合。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>訂單的集合。</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] OrderOption option)
        {
            if (option.BuyerId == default)
                option.BuyerId = currentUser.UserId;

            var orders = await orderService.GetOrdersAsync(option);
            Response.Headers.Add("X-Total-Count", orders.ItemCount.ToString());

            return Ok(orders.Items);
        }

        /// <summary>
        /// 建立訂單。
        /// </summary>
        /// <param name="command">建立訂單命令。</param>
        /// <returns>201 Created。</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateOrderCommand command)
        {
            command.UserId = currentUser.UserId;
            var order = await orderService.CreateOrderAsync(command);

            return CreatedAtAction("Get", new { id = order.Id }, order);
        }
    }
}