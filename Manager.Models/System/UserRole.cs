using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.System
{
    /// <summary>
    /// 使用者角色。
    /// </summary>
    [Table("UserRole", Schema = "System")]
    public class UserRole
    {
        /// <summary>
        /// 取得或設定使用者 ID。
        /// </summary>
        /// <value>使用者 ID。</value>
        public int UserId { get; set; }

        /// <summary>
        /// 取得或設定角色ID。
        /// </summary>
        /// <value>角色 ID。</value>
        public int RoleId { get; set; }

        /// <summary>
        /// 取得或設定使用者。
        /// </summary>
        /// <value>使用者。</value>
        public virtual User User { get; set; }

        /// <summary>
        /// 取得或設定角色。
        /// </summary>
        /// <value>角色。</value>
        public virtual Role Role { get; set; }
    }
}