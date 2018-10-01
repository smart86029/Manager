namespace Manager.Domain.Models.System
{
    /// <summary>
    /// 使用者角色。
    /// </summary>
    public class UserRole : Entity
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
        public User User { get; set; }

        /// <summary>
        /// 取得或設定角色。
        /// </summary>
        /// <value>角色。</value>
        public Role Role { get; set; }
    }
}