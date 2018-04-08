using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.System
{
    /// <summary>
    /// 菜單類別。
    /// </summary>
    [Table("Menu", Schema = "System")]
    public class Menu
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        [Display(Name = "ID")]
        public int MenuId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        [Required]
        [StringLength(50, ErrorMessage = "長度不可超過 50")]
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定區域。
        /// </summary>
        /// <value>區域。</value>
        [Display(Name = "區域")]
        [StringLength(50, ErrorMessage = "長度不可超過 50")]
        public string Area { get; set; }

        /// <summary>
        /// 取得或設定控制器。
        /// </summary>
        /// <value>
        /// 控制器。
        /// </value>
        [Display(Name = "控制器")]
        [StringLength(50, ErrorMessage = "長度不可超過 50")]
        public string Controller { get; set; }

        /// <summary>
        /// 取得或設定動作。
        /// </summary>
        /// <value>
        /// 動作。
        /// </value>
        [Display(Name = "動作")]
        [StringLength(50, ErrorMessage = "長度不可超過 50")]
        public string Action { get; set; }

        /// <summary>
        /// 取得或設定描述。
        /// </summary>
        /// <value>
        /// 描述。
        /// </value>
        [Display(Name = "描述")]
        [StringLength(100, ErrorMessage = "長度不可超過 100")]
        public string Description { get; set; }

        /// <summary>
        /// 取得或設定排序。
        /// </summary>
        /// <value>
        /// 排序。
        /// </value>
        [Display(Name = "排序")]
        [Required]
        public int Order { get; set; }

        /// <summary>
        /// 取得或設定值，這個值指出是否啟用。
        /// </summary>
        /// <value>
        /// 如果啟用則為 <c>true</c>，否則為 <c>false</c>。
        /// </value>
        [Display(Name = "是否啟用")]
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 取得或設定父節點ID。
        /// </summary>
        /// <value>
        /// 父節點ID。
        /// </value>
        [Display(Name = "父節點ID")]
        public int? ParentId { get; set; }

        /// <summary>
        /// 取得或設定父節點。
        /// </summary>
        /// <value>
        /// 父節點。
        /// </value>
        [ForeignKey("ParentId")]
        public virtual Menu Parent { get; set; }

        /// <summary>
        /// 取得或設定角色的集合。
        /// </summary>
        /// <value>
        /// 角色的集合。
        /// </value>
        public virtual ICollection<Role> Roles { get; set; }
    }
}