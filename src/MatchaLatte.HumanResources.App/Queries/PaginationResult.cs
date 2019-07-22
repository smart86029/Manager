using System.Collections.Generic;

namespace MatchaLatte.HumanResources.App.Queries
{
    public class PaginationResult<T>
    {
        public ICollection<T> Items { get; set; }

        public int ItemCount { get; set; }
    }
}