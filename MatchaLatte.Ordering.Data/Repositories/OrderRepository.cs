using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Ordering.Data.Repositories
{
    /// <summary>
    /// 訂單存放庫。
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingContext context;

        /// <summary>
        /// 初始化 <see cref="OrderRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">訂購內容。</param>
        public OrderRepository(OrderingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得訂單。
        /// </summary>
        /// <param name="orderId">訂單 ID。</param>
        /// <returns>訂單。</returns>
        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            var result = await context
                .Set<Order>()
                .Include(o => o.OrderItems)
                .Include(nameof(OrderItem.OrderItemProductAccessories))
                .SingleOrDefaultAsync(o => o.Id == orderId);

            return result;
        }

        /// <summary>
        /// 加入訂單。
        /// </summary>
        /// <param name="order">訂單。</param>
        public void Add(Order order)
        {
            context.Set<Order>().Add(order);
        }

        /// <summary>
        /// 更新訂單。
        /// </summary>
        /// <param name="order">訂單。</param>
        public void Update(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }
    }
}