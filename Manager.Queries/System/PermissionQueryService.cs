using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Manager.App.Queries.System;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;

namespace Manager.Queries.System
{
    /// <summary>
    /// 權限查詢服務。
    /// </summary>
    public class PermissionQueryService : IPermissionQueryService
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="PermissionQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public PermissionQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有權限。</returns>
        public async Task<PaginationResult<PermissionSummary>> GetPermissionsAsync(PaginationOption option)
        {
            var sql = $@"
                SELECT PermissionId, Name, IsEnabled
                FROM [System].[Permission]
                ORDER BY PermissionId
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [System].[Permission]";
            var param = new
            {
                Skip = (option.PageIndex - 1) * option.PageSize,
                Take = option.PageSize
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var permissions = await connection.QueryAsync<PermissionSummary>(sql, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount);
                var result = new PaginationResult<PermissionSummary>
                {
                    Items = permissions.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }
    }
}