using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Queries.Stores;
using MatchaLatte.Ordering.App.Services;

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
            SqlMapper.SetTypeMap(typeof(ProductCategoryDetail), new TypeMap<ProductCategoryDetail>());
            SqlMapper.SetTypeMap(typeof(ProductDetail), new TypeMap<ProductDetail>());
            SqlMapper.SetTypeMap(typeof(ProductItemDetail), new TypeMap<ProductItemDetail>());
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
                var stores = new Dictionary<Guid, StoreDetail>();
                var categories = new Dictionary<Guid, ProductCategoryDetail>();
                var products = new Dictionary<Guid, ProductDetail>();
                var result = await connection.QueryAsync(sql, (StoreDetail s, PhoneDetail phone, AddressDetail a, ProductCategoryDetail c, ProductDetail p, ProductItemDetail i) =>
                {
                    if (!stores.TryGetValue(s.StoreId, out StoreDetail store))
                    {
                        stores.Add(s.StoreId, store = s);
                    }

                    if (string.IsNullOrWhiteSpace(store.Phone))
                        store.Phone = phone.AreaCode + phone.BaseNumber + phone.Extension;

                    store.Address = a;

                    if (c == default(ProductCategoryDetail))
                        return store;
                    if (!categories.TryGetValue(c.ProductCategoryId, out ProductCategoryDetail category))
                    {
                        categories.Add(c.ProductCategoryId, category = c);
                        store.ProductCategories.Add(category);
                    }

                    if (p == default(ProductDetail))
                        return store;
                    if (!products.TryGetValue(p.ProductId, out ProductDetail product))
                    {
                        products.Add(p.ProductId, product = p);
                        category.Products.Add(product);
                    }

                    if (i == default(ProductItemDetail))
                        return store;
                    product.ProductItems.Add(i);

                    return store;
                }, param, splitOn: "AreaCode, PostalCode, ProductCategoryId, ProductId, ProductItemId");

                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 取得新店家。
        /// </summary>
        /// <returns>新店家。</returns>
        public Task<StoreDetail> GetNewStoreAsync()
        {
            var result = new StoreDetail
            {
                ProductCategories = new List<ProductCategoryDetail>
                {
                    new ProductCategoryDetail
                    {
                        Name = "Default",
                        IsDefault = true
                    }
                }
            };

            return Task.FromResult(result);
        }
    }
}