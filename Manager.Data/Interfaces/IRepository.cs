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
        /// <param name="keyValues">主索引鍵值。</param>
        /// <returns>找到的實體，或 null。</returns>
        Task<TEntity> FindAsync(params object[] keyValues);

        /// <summary>
        /// 傳回存放庫中符合指定之條件的唯一實體；如果找不到，則傳回預設值。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>存放庫中符合指定之條件的唯一實體；如果找不到，則為預設值。</returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);

        /// <summary>
        /// 傳回存放庫中符合指定之條件的實體。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>存放庫中符合指定之條件的實體。</returns>
        Task<IEnumerable<TEntity>> ManyAsync(PaginationSpecification<TEntity> specification);

        /// <summary>
        /// 傳回存放庫中符合指定之條件的數量。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <returns>符合指定之條件的數量。</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

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