using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manager.Models.System;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 店家。
    /// </summary>
    [Table("Store", Schema = "GroupBuying")]
    public class Store
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int StoreId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        [Required]
        [StringLength(32, ErrorMessage = "長度不可超過 32")]
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定描述。
        /// </summary>
        /// <value>描述。</value>
        [StringLength(512, ErrorMessage = "長度不可超過 512")]
        public string Description { get; set; }

        /// <summary>
        /// 取得或設定電話。
        /// </summary>
        /// <value>電話。</value>
        [StringLength(32, ErrorMessage = "長度不可超過 32")]
        public string Phone { get; set; }

        /// <summary>
        /// 取得或設定地址。
        /// </summary>
        /// <value>地址。</value>
        [StringLength(128, ErrorMessage = "長度不可超過 128")]
        public string Address { get; set; }

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
        /// 取得或設定商品的集合。
        /// </summary>
        /// <value>商品。</value>
        public ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// 取得或設定團店家的集合。
        /// </summary>
        /// <value>團店家的集合。</value>
        public ICollection<GroupStore> GroupStores { get; set; } = new List<GroupStore>();
    }
}