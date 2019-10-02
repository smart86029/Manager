using System.Threading.Tasks;
using MatchaLatte.Common.Queries;

namespace MatchaLatte.Ordering.App.Orders
{
    /// <summary>
    /// 訂單查詢服務。
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 取得訂單的集合。
        /// </summary>
        /// <param name="option">訂單選項。</param>
        /// <returns>訂單的集合。</returns>
        Task<PaginationResult<OrderSummary>> GetOrdersAsync(OrderOption option);

        /// <summary>
        /// 建立訂單。
        /// </summary>
        /// <param name="command">建立訂單命令。</param>
        /// <returns>訂單。</returns>
        Task<OrderDetail> CreateOrderAsync(CreateOrderCommand command);
    }
}