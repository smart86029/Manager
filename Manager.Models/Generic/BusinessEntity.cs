using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models
{
    /// <summary>
    /// 商業實體。
    /// </summary>
    [Table("BusinessEntity", Schema = "Generic")]
    public class BusinessEntity
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        [Display(Name = "ID")]
        public int BusinessEntityId { get; set; }
    }
}
