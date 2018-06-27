using System.Collections.Generic;
using Manager.Common;

namespace Manager.Domain.Models.System
{
    /// <summary>
    /// 使用者。
    /// </summary>
    public class User : IAggregateRoot
    {
        private ICollection<UserRole> userRoles;

        public User(string userName, string password, bool isEnabled, int businessEntityId)
            : this(0, userName, password, isEnabled, businessEntityId)
        {
        }

        public User(int userId, string userName, string password, bool isEnabled, int businessEntityId)
        {
            UserId = userId;
            UserName = userName;
            PasswordHash = CryptographyUtility.Hash(password);
            IsEnabled = isEnabled;
            BusinessEntityId = businessEntityId;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int UserId { get; private set; }

        /// <summary>
        /// 取得使用者名稱。
        /// </summary>
        /// <value>使用者名稱。</value>
        public string UserName { get; private set; }

        /// <summary>
        /// 取得密碼雜湊。
        /// </summary>
        /// <value>密碼雜湊。</value>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// 取得值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 取得商業實體ID。
        /// </summary>
        /// <value>商業實體ID。</value>
        public int BusinessEntityId { get; private set; }

        ///// <summary>
        ///// 取得商業實體。
        ///// </summary>
        ///// <value>商業實體。</value>
        //public BusinessEntity BusinessEntity { get; set; }

        /// <summary>
        /// 取得使用者角色的集合。
        /// </summary>
        /// <value>使用者角色的集合。</value>
        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }
    }
}