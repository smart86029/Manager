using System.Collections.Generic;

namespace MatchaLatte.Catalog.App.Queries
{
    public class PaginationResult<T>
    {
        public ICollection<T> Items { get; set; }

        public int ItemCount { get; set; }
    }
}