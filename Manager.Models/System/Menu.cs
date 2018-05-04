using System.Collections.Generic;

namespace Manager.Models.System
{
    /// <summary>
    /// 菜單。
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int MenuId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定區域。
        /// </summary>
        /// <value>區域。</value>
        public string Area { get; set; }

        /// <summary>
        /// 取得或設定控制器。
        /// </summary>
        /// <value>控制器。</value>
        public string Controller { get; set; }

        /// <summary>
        /// 取得或設定動作。
        /// </summary>
        /// <value>動作。</value>
        public string Action { get; set; }

        /// <summary>
        /// 取得或設定描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; set; }

        /// <summary>
        /// 取得或設定排序。
        /// </summary>
        /// <value>排序。</value>
        public int Order { get; set; }

        /// <summary>
        /// 取得或設定值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 取得或設定父節點ID。
        /// </summary>
        /// <value>父節點ID。</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// 取得或設定父節點。
        /// </summary>
        /// <value>父節點。</value>
        public Menu Parent { get; set; }

        /// <summary>
        /// 取得或設定角色菜單的集合。
        /// </summary>
        /// <value>角色菜單的集合。</value>
        public ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
    }
}