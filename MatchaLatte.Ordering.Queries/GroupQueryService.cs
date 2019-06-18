using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MatchaLatte.Ordering.App.Queries;

using MatchaLatte.Ordering.App.Services;

namespace MatchaLatte.Ordering.Queries
{
    /// <summary>
    /// 團查詢服務。
    /// </summary>
    //public class GroupQueryService : IGroupQueryService
    //{
    //    private readonly string connectionString;
    //    private readonly PictureSettings pictureSettings;

    //    /// <summary>
    //    /// 初始化 <see cref="GroupQueryService"/> 類別的新執行個體。
    //    /// </summary>
    //    /// <param name="connectionString">連接字串。</param>
    //    /// <param name="pictureSettings">圖片設定。</param>
    //    public GroupQueryService(string connectionString, PictureSettings pictureSettings)
    //    {
    //        this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
    //        this.pictureSettings = pictureSettings ?? throw new ArgumentNullException(nameof(pictureSettings));
    //    }

    //    /// <summary>
    //    /// 取得所有團。
    //    /// </summary>
    //    /// <param name="option">分頁查詢。</param>
    //    /// <returns>所有團。</returns>
    //    public async Task<PaginationResult<GroupSummary>> GetGroupsAsync(GroupOption option)
    //    {
    //        var whereCondition = option.SearchType == GroupSearchType.Active ? "WHERE [g].[StartTime] < GETDATE() AND [g].[EndTime] > GETDATE()" : string.Empty;
    //        var sql = $@"
    //            SELECT [g].[GroupId], [g].[StartTime], [g].[EndTime], [g].[CreatedOn],
    //                [s].[Name], @BaseUri + CAST([s].[StoreId] AS NVARCHAR(36)) + '/logo' AS [LogoUri]
    //            FROM [Ordering].[Group] AS [g]
    //            INNER JOIN [Ordering].[Store] AS [s] ON [g].[StoreId] = [s].[StoreId]
    //            {whereCondition}
    //            ORDER BY [g].[GroupId]
    //            OFFSET @Offset ROWS
    //            FETCH NEXT @Limit ROWS ONLY";
    //        var sqlCount = $@"
    //            SELECT COUNT(*) FROM [Ordering].[Group]";
    //        var param = new
    //        {
    //            option.Offset,
    //            option.Limit,
    //            pictureSettings.BaseUri
    //        };

    //        using (var connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            var groups = await connection.QueryAsync(sql, (GroupSummary g, StoreSummary s) =>
    //            {
    //                g.Store = s;

    //                return g;
    //            }, param, splitOn: "Name");
    //            var count = await connection.QuerySingleAsync<int>(sqlCount);
    //            var result = new PaginationResult<GroupSummary>
    //            {
    //                Items = groups.AsList(),
    //                ItemCount = count
    //            };

    //            return result;
    //        }
    //    }

    //    /// <summary>
    //    /// 取得團。
    //    /// </summary>
    //    /// <param name="groupId">團 ID。</param>
    //    /// <returns>團。</returns>
    //    public async Task<GroupDetail> GetGroupAsync(Guid groupId)
    //    {
    //        var sql = $@"
    //            SELECT [g].[GroupId], [g].[StartTime], [g].[EndTime], [g].[Remark], [s].[StoreId], [s].[Name]
    //            FROM [Ordering].[Group] AS [g]
    //            INNER JOIN [Ordering].[Store] AS [s] ON [g].[StoreId] = [s].[StoreId]
    //            WHERE [g].[GroupId] = @GroupId";
    //        var param = new { GroupId = groupId };

    //        using (var connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            var result = await connection.QueryAsync(sql, (GroupDetail g, StoreDetail s) =>
    //            {
    //                g.Store = s;

    //                return g;
    //            }, param, splitOn: "StoreId");

    //            return result.FirstOrDefault();
    //        }
    //    }

    //    /// <summary>
    //    /// 取得新團。
    //    /// </summary>
    //    /// <param name="storeId">店家 ID。</param>
    //    /// <returns>新團。</returns>
    //    public async Task<GroupDetail> GetNewGroupAsync(Guid storeId)
    //    {
    //        var sql = $@"
    //            SELECT [StoreId], [Name]
    //            FROM [Ordering].[Store]
    //            WHERE [StoreId] = @StoreId";
    //        var param = new { StoreId = storeId };

    //        using (var connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            var store = await connection.QuerySingleAsync<StoreDetail>(sql, param);
    //            var result = new GroupDetail
    //            {
    //                StartTime = DateTime.Now,
    //                EndTime = DateTime.Now.AddDays(1),
    //                Store = store
    //            };

    //            return result;
    //        }
    //    }
    //}
}