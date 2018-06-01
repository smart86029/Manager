namespace Manager.Models.Generic
{
    /// <summary>
    /// 商業實體。
    /// </summary>
    public abstract class BusinessEntity
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int BusinessEntityId { get; set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        /// <value>顯示名稱。</value>
        public abstract string DisplayName { get; }
    }
}