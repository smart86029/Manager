using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manager.Models.System;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 團。
    /// </summary>
    [Table("Group", Schema = "GroupBuying")]
    public class Group
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int GroupId { get; set; }

        /// <summary>
        /// 取得或設定開始時間。
        /// </summary>
        /// <value>開始時間。</value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 取得或設定結束時間。
        /// </summary>
        /// <value>結束時間。</value>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 取得或設定備註。
        /// </summary>
        /// <value>備註。</value>
        [StringLength(512, ErrorMessage = "長度不可超過 512")]
        public string Remark { get; set; }

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
        /// 取得或設定建立者。
        /// </summary>
        /// <value>建立者。</value>
        [ForeignKey(nameof(CreatedBy))]
        public User Creator { get; set; }

        /// <summary>
        /// 取得或設定團店家的集合。
        /// </summary>
        /// <value>團店家的集合。</value>
        public ICollection<GroupStore> GroupStores { get; set; } = new List<GroupStore>();
    }
}