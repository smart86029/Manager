using System.Collections.Generic;

namespace MatchaLatte.Common.Queries
{
    /// <summary>
    /// 分頁結果。
    /// </summary>
    /// <typeparam name="TResult">結果類型。</typeparam>
    public class PaginationResult<TResult>
    {
        public ICollection<TResult> Items { get; set; }

        public int ItemCount { get; set; }
    }
}