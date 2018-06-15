using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 以 EntityFramework 實作的存放庫。
    /// </summary>
    /// <typeparam name="TEntity">實體的類型。</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
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
        /// <param name="keyValues">主索引鍵值。</param>
        /// <returns>找到的實體，或 null。</returns>
        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await Context.Set<TEntity>().FindAsync(keyValues);
        }

        /// <summary>
        /// 傳回存放庫中符合指定之條件的唯一實體；如果找不到，則傳回預設值。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <param name="paths">Lambda 運算式，表示要包含的路徑。</param>
        /// <returns>存放庫中符合指定之條件的唯一實體；如果找不到，則為預設值。</returns>
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            foreach (var path in paths)
                query = query.Include(path);

            return await query.SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 傳回存放庫中符合指定之條件的實體。
        /// </summary>
        /// <param name="specification">分頁查詢規格。</param>
        /// <returns>存放庫中符合指定之條件的實體。</returns>
        public virtual async Task<IEnumerable<TEntity>> ManyAsync(PaginationSpecification<TEntity> specification)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            specification = specification ?? new PaginationSpecification<TEntity>();
            foreach (var include in specification.Includes)
                query = query.Include(include);

            if (specification.Criteria != null)
                query = query.Where(specification.Criteria);
            if (specification.PageSize > 0 && specification.PageIndex > 0)
                query = query.Skip(specification.PageSize * (specification.PageIndex - 1));
            if (specification.PageSize > 0)
                query = query.Take(specification.PageSize);

            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 傳回存放庫中符合指定之條件的數量。
        /// </summary>
        /// <param name="predicate">用來測試每個實體是否符合條件的函式。</param>
        /// <returns>符合指定之條件的數量。</returns>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.CountAsync();
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