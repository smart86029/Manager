using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Queries.Orders;

namespace MatchaLatte.Ordering.App.Services
{
    /// <summary>
    /// 訂單查詢服務。
    /// </summary>
    public interface IOrderQueryService
    {
        Task<PaginationResult<OrderSummary>> GetOrdersAsync(OrderOption option);
    }
}