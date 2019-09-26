namespace MatchaLatte.Common.Queries
{
    /// <summary>
    /// 分頁選項。
    /// </summary>
    public class PaginationOption
    {
        private int offset = 0;
        private int limit = 10;

        /// <summary>
        /// 取得或設定略過的筆數。
        /// </summary>
        public int Offset
        {
            get => offset;
            set => offset = value > 0 ? value : offset;
        }

        /// <summary>
        /// 取得或設定限制的筆數。
        /// </summary>
        public int Limit
        {
            get => limit;
            set => limit = value > 0 && value <= 100 ? value : limit;
        }
    }
}