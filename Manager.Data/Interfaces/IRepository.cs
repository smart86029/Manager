using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Manager.Data
{
    /// <summary>
    /// 存放庫介面。
    /// </summary>
    /// <typeparam name="TEntity">實體的類型。</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 尋找具有給定主索引鍵值的實體。
        /// </summary>
        /// <param name="keyValues">要尋找之實體的主索引鍵值。</param>
        /// <returns>找到的實體或 null。</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// 非同步尋找具有給定主索引鍵值的實體。
        /// </summary>
        /// <param name="keyValues">要尋找之實體的主索引鍵值。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含找到的實體，或 null。</returns>
        Task<TEntity> FindAsync(params object[] keyValues);

        /// <summary>
        /// 傳回存放庫中符合指定之條件的第一個項目；如果找不到這類實體，則傳回預設值。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>如果存放庫是空的，或是沒有任何實體通過函式所指定的測試，則為預設值，否則為存放庫中通過函式指定之測試的第一個實體。</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);

        /// <summary>
        /// 非同步傳回存放庫中符合指定之條件的第一個實體；如果找不到這類實體，則傳回預設值。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>表示非同步作業的工作。 如果存放庫是空的，或是沒有任何實體通過函式所指定的測試，則為預設值，否則為存放庫中通過函式指定之測試的第一個實體。</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);

        /// <summary>
        /// 傳回存放庫中符合指定之條件的實體。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns><see cref="IEnumerable{TEntity}"/>，其中包含存放庫中通過函式指定之測試的實體。</returns>
        IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);

        /// <summary>
        /// 非同步傳回存放庫中符合指定之條件的實體。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含<see cref="IEnumerable{TEntity}"/>，其中包含存放庫中通過函式指定之測試的實體。</returns>
        Task<IEnumerable<TEntity>> ManyAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);

        /// <summary>
        /// 新增實體。
        /// </summary>
        /// <param name="entity">要新增的實體。</param>
        void Create(TEntity entity);

        /// <summary>
        /// 更改實體。
        /// </summary>
        /// <param name="entity">要更改的實體。</param>
        void Update(TEntity entity);

        /// <summary>
        /// 刪除實體。
        /// </summary>
        /// <param name="entity">要刪除的實體。</param>
        void Delete(TEntity entity);
    }
}