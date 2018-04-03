using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models
{
    /// <summary>
    /// 店家。
    /// </summary>
    [Table("Store", Schema = "Commerce")]
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
        [StringLength(20, ErrorMessage = "長度不可超過 20")]
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
        [StringLength(20, ErrorMessage = "長度不可超過 20")]
        public string Phone { get; set; }

        /// <summary>
        /// 取得或設定地址。
        /// </summary>
        /// <value>地址。</value>
        [StringLength(128, ErrorMessage = "長度不可超過 128")]
        public string Address { get; set; }

        /// <summary>
        /// 取得或設定新增者ID。
        /// </summary>
        /// <value>新增者ID。</value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// 取得或設定新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 取得或設定修改者ID。
        /// </summary>
        /// <value>修改者ID。</value>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// 取得或設定修改者。
        /// </summary>
        /// <value>修改者。</value>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// 取得或設定建立者。
        /// </summary>
        /// <value>建立者。</value>
        [ForeignKey("CreatedBy")]
        public virtual User Creator { get; set; }

        /// <summary>
        /// 取得或設定修改者。
        /// </summary>
        /// <value>修改者。</value>
        [ForeignKey("UpdatedBy")]
        public virtual User Updater { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        //[InverseProperty("Store")]
        //public virtual ICollection<Product> Products { get; set; }
    }
}