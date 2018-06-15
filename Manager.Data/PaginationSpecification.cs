using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Manager.Data
{
    public class PaginationSpecification<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}