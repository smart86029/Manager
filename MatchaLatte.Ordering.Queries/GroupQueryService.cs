using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Queries.Groups;
using MatchaLatte.Ordering.App.Services;

namespace MatchaLatte.Ordering.Queries
{
    /// <summary>
    /// 團查詢服務。
    /// </summary>
    public class GroupQueryService : IGroupQueryService
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="GroupQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public GroupQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// 取得所有團。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有團。</returns>
        public async Task<PaginationResult<GroupSummary>> GetGroupsAsync(PaginationOption option)
        {
            var sql = $@"
                SELECT [g].[GroupId], [g].[StartTime], [g].[EndTime], [g].[CreatedOn], [s].[Name]
                FROM [Ordering].[Group] AS [g]
                INNER JOIN [Ordering].[Store] AS [s] ON [g].[StoreId] = [s].[StoreId]
                ORDER BY [g].[GroupId]
                OFFSET @Offset ROWS
                FETCH NEXT @Limit ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [Ordering].[Group]";
            var param = new
            {
                option.Offset,
                option.Limit
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var groups = await connection.QueryAsync<GroupSummary>(sql, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount);
                var result = new PaginationResult<GroupSummary>
                {
                    Items = groups.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        public Task<GroupDetail> GetGroupAsync(Guid groupId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得新團。
        /// </summary>
        /// <returns>新團。</returns>
        public Task<GroupDetail> GetNewGroupAsync()
        {
            throw new NotImplementedException();
        }
    }
}