using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models
{
    /// <summary>
    /// 使用者類別。
    /// </summary>
    [Table("User", Schema = "System")]
    public class User
    {
        /// <summary>
        /// 初始化 <see cref="User"/> 類別的新執行個體。
        /// </summary>
        public User()
        {
            Roles = new List<Role>();
        }

        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>
        /// 主鍵。
        /// </value>
        [Display(Name = "ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 取得或設定使用者名稱。
        /// </summary>
        /// <value>
        /// 使用者名稱。
        /// </value>
        [Display(Name = "使用者名稱")]
        [Required]
        [StringLength(20, ErrorMessage = "長度不可超過 20")]
        public string UserName { get; set; }

        /// <summary>
        /// 取得或設定密碼雜湊。
        /// </summary>
        /// <value>
        /// 密碼雜湊。
        /// </value>
        [Display(Name = "密碼雜湊")]
        public string PasswordHash { get; set; }

        /// <summary>
        /// 取得或設定值，這個值指出是否啟用。
        /// </summary>
        /// <value>
        /// 如果啟用則為 <c>true</c>，否則為 <c>false</c>。
        /// </value>
        [Display(Name = "是否啟用")]
        [Required]
        public bool IsActivated { get; set; }

        /// <summary>
        /// 取得或設定商業實體ID。
        /// </summary>
        /// <value>
        /// 商業實體ID。
        /// </value>
        [Display(Name = "商業實體ID")]
        public int? BusinessEntityId { get; set; }

        /// <summary>
        /// 取得或設定商業實體。
        /// </summary>
        /// <value>
        /// 商業實體。
        /// </value>
        [ForeignKey("BusinessEntityId")]
        public virtual BusinessEntity BusinessEntity { get; set; }

        /// <summary>
        /// 取得或設定角色。
        /// </summary>
        /// <value>
        /// 角色。
        /// </value>
        public virtual ICollection<Role> Roles { get; set; }
    }
}
