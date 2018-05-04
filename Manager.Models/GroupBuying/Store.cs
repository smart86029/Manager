using System;
using System.Collections.Generic;
using Manager.Models.Generic;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 店家。
    /// </summary>
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
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; set; }

        /// <summary>
        /// 取得或設定電話。
        /// </summary>
        /// <value>電話。</value>
        public string Phone { get; set; }

        /// <summary>
        /// 取得或設定地址。
        /// </summary>
        /// <value>地址。</value>
        public string Address { get; set; }

        /// <summary>
        /// 取得或設定備註。
        /// </summary>
        /// <value>備註。</value>
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
        /// 取得或設定新增者。
        /// </summary>
        /// <value>新增者。</value>
        public BusinessEntity Creator { get; set; }

        /// <summary>
        /// 取得或設定商品分類的集合。
        /// </summary>
        /// <value>商品分類。</value>
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        /// <summary>
        /// 取得或設定團店家的集合。
        /// </summary>
        /// <value>團店家的集合。</value>
        public ICollection<GroupStore> GroupStores { get; set; } = new List<GroupStore>();
    }
}