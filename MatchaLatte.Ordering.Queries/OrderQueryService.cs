using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Queries.Orders;
using MatchaLatte.Ordering.App.Services;

namespace MatchaLatte.Ordering.Queries
{
    /// <summary>
    /// 訂單查詢服務。
    /// </summary>
    public class OrderQueryService : IOrderQueryService
    {
        private readonly string connectionString;

        /// <summary>
        /// 初始化 <see cref="OrderQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public OrderQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<PaginationResult<OrderSummary>> GetOrdersAsync(OrderOption option)
        {
            var condition = "[BuyerId] = @BuyerId";
            var sql = $@"
                SELECT [a].[OrderId], [a].[OrderStatus], [a].[CreatedOn]
                FROM (
                    SELECT [OrderId], [OrderStatus], [CreatedOn]
                    FROM [Ordering].[Order] AS [a]
                    WHERE {condition}
                ) AS [a]
			    LEFT JOIN (
                    SELECT [OrderItemId], [ProductName], [ProductItemName], [ProductItemPrice], [Quantity], [OrderId]
                    FROM [Ordering].[OrderItem]
                ) AS [b] ON [a].[OrderId] = [b].[OrderId]
                ORDER BY [a].[OrderId]
                OFFSET @Offset ROWS
                FETCH NEXT @Limit ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [Ordering].[Order] WHERE {condition}";
            var param = new
            {
                option.GroupId,
                option.BuyerId,
                option.Offset,
                option.Limit
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var orders = await connection.QueryAsync<OrderSummary>(sql, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount);
                var result = new PaginationResult<OrderSummary>
                {
                    Items = orders.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }
    }
}