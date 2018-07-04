using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Manager.App.Queries.GroupBuying;
using Manager.App.ViewModels;
using Manager.App.ViewModels.GroupBuying;

namespace Manager.Queries.GroupBuying
{
    /// <summary>
    /// 店家查詢服務。
    /// </summary>
    public class StoreQueryService : IStoreQueryService
    {
        private string connectionString;

        /// <summary>
        /// 初始化 <see cref="StoreQueryService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="connectionString">連接字串。</param>
        public StoreQueryService(string connectionString)
        {
            this.connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// 取得所有店家。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有店家。</returns>
        public async Task<PaginationResult<StoreSummary>> GetStoresAsync(PaginationOption option)
        {
            var sql = $@"
                SELECT [StoreId], [Name], [CreatedOn]
                FROM [GroupBuying].[Store]
                ORDER BY [StoreId]
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [GroupBuying].[Store]";
            var param = new
            {
                Skip = (option.PageIndex - 1) * option.PageSize,
                Take = option.PageSize
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var stores = await connection.QueryAsync<StoreSummary>(sql, param);
                var count = await connection.QuerySingleAsync<int>(sqlCount);
                var result = new PaginationResult<StoreSummary>
                {
                    Items = stores.AsList(),
                    ItemCount = count
                };

                return result;
            }
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public async Task<Store> GetStoreAsync(int storeId)
        {
            var sql = $@"
            	SELECT [s].[StoreId], [s].[Name], [s].[Description], [s].[Remark],
                    [s].[AreaCode], [s].[BaseNumber], [s].[Extension],
					[s].[PostalCode], [s].[Country], [s].[City], [s].[District], [s].[Street],
					[c].[ProductCategoryId], [c].[Name] AS [CategoryName]
				FROM (
                    SELECT [StoreId], [Name], [Description], [AreaCode], [BaseNumber], [Extension], [PostalCode], [Country], [City], [District], [Street], [Remark]
                    FROM [GroupBuying].[Store]
                    WHERE [StoreId] = @StoreId
                ) AS [s]
				LEFT JOIN (
                    SELECT [ProductCategoryId], [Name], [StoreId]
                    FROM [GroupBuying].[ProductCategory]
                    WHERE [StoreId] = @StoreId
                ) AS [c] ON [s].[StoreId] = [c].[StoreId]";
            var param = new { StoreId = storeId };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var stores = new Dictionary<int, Store>();
                var result = await connection.QueryAsync(sql, (Store s, Phone p, Address a, Store.ProductCategory c) =>
                {
                    if (!stores.TryGetValue(s.StoreId, out Store store))
                    {
                        store = s;
                        stores.Add(s.StoreId, s);
                    }

                    if (string.IsNullOrWhiteSpace(store.Phone))
                        store.Phone = p.AreaCode + p.BaseNumber + p.Extension;
                    if (string.IsNullOrWhiteSpace(store.Address))
                        store.Address = a.City + a.District + a.Street;

                    store.ProductCategories.Add(c);

                    return store;
                }, param, splitOn: "AreaCode, PostalCode, ProductCategoryId");

                return result.FirstOrDefault();
            }
        }
    }
}