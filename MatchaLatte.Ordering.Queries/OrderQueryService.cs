using System;
using System.Collections.Generic;
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
                SELECT [a].[Id], [a].[OrderStatus], [a].[CreatedOn],
                    [b].[Id], [b].[ProductName], [b].[ProductItemName], [b].[ProductItemPrice], [b].[Quantity]
                FROM (
                    SELECT [Id], [OrderStatus], [CreatedOn]
                    FROM [Ordering].[Order] AS [a]
                    WHERE {condition}
                ) AS [a]
			    LEFT JOIN (
                    SELECT [Id], [ProductName], [ProductItemName], [ProductItemPrice], [Quantity], [OrderId]
                    FROM [Ordering].[OrderItem]
                ) AS [b] ON [a].[Id] = [b].[OrderId]
                ORDER BY [a].[Id]
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
                var orders = new Dictionary<Guid, OrderSummary>();
                var queryResult = await connection.QueryAsync(sql, (OrderSummary o, OrderItemDto i) =>
                {
                    if (!orders.TryGetValue(o.Id, out OrderSummary order))
                        orders.Add(o.Id, order = o);

                    if (i == default)
                        return order;

                    order.OrderItems.Add(i);

                    return order;
                }, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount, param);
                var result = new PaginationResult<OrderSummary>
                {
                    Items = queryResult.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }
    }
}