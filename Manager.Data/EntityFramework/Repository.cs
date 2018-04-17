using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 存放庫。
    /// </summary>
    /// <typeparam name="TEntity">實體的類型。</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 初始化 <see cref="Repository{TEntity}"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db"><see cref="DbContext"/> 類別的執行個體</param>
        public Repository(DbContext db)
        {
            Context = db;
        }

        /// <summary>
        /// 取得內容執行個體。
        /// </summary>
        /// <value>
        /// 內容執行個體。
        /// </value>
        protected DbContext Context { get; }

        /// <summary>
        /// 尋找具有給定主索引鍵值的實體。
        /// </summary>
        /// <param name="keyValues">要尋找之實體的主索引鍵值。</param>
        /// <returns>找到的實體或 null。</returns>
        public virtual TEntity Find(params object[] keyValues)
        {
            return Context.Set<TEntity>().Find(keyValues);
        }

        /// <summary>
        /// 非同步尋找具有給定主索引鍵值的實體。
        /// </summary>
        /// <param name="keyValues">要尋找之實體的主索引鍵值。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含找到的實體，或 null。</returns>
        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await Context.Set<TEntity>().FindAsync(keyValues);
        }

        /// <summary>
        /// 傳回存放庫中符合指定之條件的第一個項目；如果找不到這類實體，則傳回預設值。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>如果存放庫是空的，或是沒有任何實體通過函式所指定的測試，則為預設值，否則為存放庫中通過函式指定之測試的第一個實體。</returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            foreach (var path in paths)
                query = query.Include(path);

            return query.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 非同步傳回存放庫中符合指定之條件的第一個實體；如果找不到這類實體，則傳回預設值。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>表示非同步作業的工作。 如果存放庫是空的，或是沒有任何實體通過函式所指定的測試，則為預設值，否則為存放庫中通過函式指定之測試的第一個實體。</returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            foreach (var path in paths)
                query = query.Include(path);

            return await query.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 傳回存放庫中符合指定之條件的實體。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns><see cref="IEnumerable{TEntity}"/>，其中包含存放庫中通過函式指定之測試的實體。</returns>
        public virtual IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            foreach (var path in paths)
                query = query.Include(path);

            if (predicate != null)
                query = query.Where(predicate);

            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// 非同步傳回存放庫中符合指定之條件的實體。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>表示非同步尋找作業的工作。 工作結果包含<see cref="IEnumerable{TEntity}"/>，其中包含存放庫中通過函式指定之測試的實體。</returns>
        public async Task<IEnumerable<TEntity>> ManyAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            foreach (var path in paths)
                query = query.Include(path);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增實體。
        /// </summary>
        /// <param name="entity">要新增的實體。/param>
        public void Create(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// 更改實體。
        /// </summary>
        /// <param name="entity">要更改的實體。</param>
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 刪除實體。
        /// </summary>
        /// <param name="entity">要刪除的實體。</param>
        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}