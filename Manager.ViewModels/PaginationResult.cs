using System.Collections.Generic;

namespace Manager.ViewModels
{
    public class PaginationResult<T> where T : class
    {
        public ICollection<T> Items { get; set; }
        public int ItemCount { get; set; }
    }
}