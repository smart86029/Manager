namespace Manager.Domain.Models.System
{
    /// <summary>
    /// 角色權限。
    /// </summary>
    public class RolePermission : IEntity
    {
        /// <summary>
        /// 取得或設定角色 ID。
        /// </summary>
        /// <value>角色 ID。</value>
        public int RoleId { get; set; }

        /// <summary>
        /// 取得或設定權限 ID。
        /// </summary>
        /// <value>權限 ID。</value>
        public int PermissionId { get; set; }

        /// <summary>
        /// 取得或設定角色。
        /// </summary>
        /// <value>角色。</value>
        public Role Role { get; set; }

        /// <summary>
        /// 取得或設定權限。
        /// </summary>
        /// <value>權限。</value>
        public Permission Permission { get; set; }
    }
}