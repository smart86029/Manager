using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.ViewModels;

namespace MatchaLatte.Ordering.Queries
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
            SqlMapper.SetTypeMap(typeof(StoreDetail.ProductCategory), new TypeMap<StoreDetail.ProductCategory>());
            SqlMapper.SetTypeMap(typeof(StoreDetail.Product), new TypeMap<StoreDetail.Product>());
            SqlMapper.SetTypeMap(typeof(StoreDetail.ProductItem), new TypeMap<StoreDetail.ProductItem>());
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
                FROM [Ordering].[Store]
                ORDER BY [StoreId]
                OFFSET @Offset ROWS
                FETCH NEXT @Limit ROWS ONLY";
            var sqlCount = $@"
                SELECT COUNT(*) FROM [Ordering].[Store]";
            var param = new
            {
                option.Offset,
                option.Limit
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
        public async Task<StoreDetail> GetStoreAsync(Guid storeId)
        {
            var sql = $@"
				SELECT [s].[StoreId], [s].[Name], [s].[Description], [s].[AreaCode], [s].[BaseNumber], [s].[Extension],
					[s].[PostalCode], [s].[Country], [s].[City], [s].[District], [s].[Street], [s].[Remark],
					[y].[ProductCategoryId], [y].[CategoryName],
					[y].[ProductId], [y].[ProductName], [y].[ProductDescription],
					[y].[ProductItemId], [y].[ItemName], [y].[Price]
				FROM (
                    SELECT [StoreId], [Name], [Description], [AreaCode], [BaseNumber], [Extension], [PostalCode], [Country], [City], [District], [Street], [Remark]
                    FROM [Ordering].[Store]
                    WHERE [StoreId] = @StoreId
                ) AS [s]
				LEFT JOIN (
                    SELECT [c].[ProductCategoryId], [c].[Name] AS [CategoryName], [c].[StoreId],
                        [x].[ProductId], [x].[ProductName], [x].[ProductDescription],
						[x].[ProductItemId], [x].[ItemName], [x].[Price]
                    FROM [Ordering].[ProductCategory] AS [c]
					LEFT JOIN (
						SELECT [p].[ProductId], [p].[Name] AS [ProductName], [p].[Description] AS [ProductDescription], [p].[ProductCategoryId],
							[i].[ProductItemId], [i].[Name] AS [ItemName], [i].[Price]
						FROM [Ordering].[Product] AS [p]
						LEFT JOIN [Ordering].[ProductItem] AS [i] ON [p].[ProductId] = [i].[ProductId]
					) AS [x] ON [c].[ProductCategoryId] = [x].[ProductCategoryId]
                    WHERE [StoreId] = @StoreId
                ) AS [y] ON [s].[StoreId] = [y].[StoreId]";
            var param = new { StoreId = storeId };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var stores = new Dictionary<int, StoreDetail>();
                var categories = new Dictionary<int, StoreDetail.ProductCategory>();
                var products = new Dictionary<int, StoreDetail.Product>();
                var result = await connection.QueryAsync(sql, (StoreDetail s, Phone phone, Address a, StoreDetail.ProductCategory c, StoreDetail.Product p, StoreDetail.ProductItem i) =>
                {
                    if (!stores.TryGetValue(s.StoreId, out StoreDetail store))
                    {
                        stores.Add(s.StoreId, store = s);
                    }

                    if (string.IsNullOrWhiteSpace(store.Phone))
                        store.Phone = phone.AreaCode + phone.BaseNumber + phone.Extension;
                    if (string.IsNullOrWhiteSpace(store.Address))
                        store.Address = a.City + a.District + a.Street;

                    if (c == default(StoreDetail.ProductCategory))
                        return store;
                    if (!categories.TryGetValue(c.ProductCategoryId, out StoreDetail.ProductCategory category))
                    {
                        categories.Add(c.ProductCategoryId, category = c);
                        store.ProductCategories.Add(category);
                    }

                    if (p == default(StoreDetail.Product))
                        return store;
                    if (!products.TryGetValue(p.ProductId, out StoreDetail.Product product))
                    {
                        products.Add(p.ProductId, product = p);
                        category.Products.Add(product);
                    }

                    if (i == default(StoreDetail.ProductItem))
                        return store;
                    product.ProductItems.Add(i);

                    return store;
                }, param, splitOn: "AreaCode, PostalCode, ProductCategoryId, ProductId, ProductItemId");

                return result.FirstOrDefault();
            }
        }
    }
}