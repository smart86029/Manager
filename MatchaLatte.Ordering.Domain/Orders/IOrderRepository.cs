using System;
using System.Threading.Tasks;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單存放庫。
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// 取得訂單。
        /// </summary>
        /// <param name="orderId">訂單 ID。</param>
        /// <returns>訂單。</returns>
        Task<Order> GetOrderAsync(Guid orderId);

        /// <summary>
        /// 加入訂單。
        /// </summary>
        /// <param name="order">訂單。</param>
        void Add(Order order);

        /// <summary>
        /// 更新訂單。
        /// </summary>
        /// <param name="order">訂單。</param>
        void Update(Order order);
    }
}