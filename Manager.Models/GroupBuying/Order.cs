using System;
using System.Collections.Generic;
using System.Text;
using Manager.Models.Generic;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 訂單。
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int OrderId { get; set; }

        /// <summary>
        /// 取得或設定新增者 ID。
        /// </summary>
        /// <value>新增者 ID。</value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// 取得或設定新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 取得或設定新增者。
        /// </summary>
        /// <value>新增者。</value>
        public BusinessEntity Creator { get; set; }
    }
}
