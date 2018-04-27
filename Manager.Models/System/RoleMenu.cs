using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.System
{
    /// <summary>
    /// 角色菜單。
    /// </summary>
    [Table("RoleMenu", Schema = "System")]
    public class RoleMenu
    {
        /// <summary>
        /// 取得或設定角色 ID。
        /// </summary>
        /// <value>角色 ID。</value>
        public int RoleId { get; set; }

        /// <summary>
        /// 取得或設定菜單 ID。
        /// </summary>
        /// <value>菜單 ID。</value>
        public int MenuId { get; set; }

        /// <summary>
        /// 取得或設定角色。
        /// </summary>
        /// <value>角色。</value>
        public Role Role { get; set; }

        /// <summary>
        /// 取得或設定菜單。
        /// </summary>
        /// <value>菜單。</value>
        public Menu Menu { get; set; }
    }
}