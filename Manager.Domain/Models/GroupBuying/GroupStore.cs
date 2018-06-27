namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 團店家。
    /// </summary>
    public class GroupStore
    {
        /// <summary>
        /// 取得或設定團 ID。
        /// </summary>
        /// <value>團 ID。</value>
        public int GroupId { get; set; }

        /// <summary>
        /// 取得或設定店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public int StoreId { get; set; }

        /// <summary>
        /// 取得或設定團。
        /// </summary>
        /// <value>團。</value>
        public Group Group { get; set; }

        /// <summary>
        /// 取得或設定店家。
        /// </summary>
        /// <value>店家。</value>
        public Store Store { get; set; }
    }
}