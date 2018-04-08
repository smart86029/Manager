using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.System
{
    /// <summary>
    /// 角色。
    /// </summary>
    [Table("Role", Schema = "System")]
    public class Role
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int RoleId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        [Required]
        [StringLength(20, ErrorMessage = "長度不可超過 20")]
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 取得或設定使用者的集合。
        /// </summary>
        /// <value>使用者的集合。</value>
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        /// <summary>
        /// 取得或設定菜單的集合。
        /// </summary>
        /// <value>菜單的集合。</value>
        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}