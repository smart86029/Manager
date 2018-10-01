using System.Collections.Generic;

namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 訂單明細。
    /// </summary>
    public class OrderDetail : Entity
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int OrderDetailId { get; set; }

        /// <summary>
        /// 取得或設定商品項目名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string ProductItemName { get; set; }

        /// <summary>
        /// 取得或設定商品項目價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal ProductItemPrice { get; set; }

        /// <summary>
        /// 取得或設定數量。
        /// </summary>
        /// <value>數量。</value>
        public int Quantity { get; set; }

        /// <summary>
        /// 取得或設定訂單 ID。
        /// </summary>
        /// <value>訂單 ID。</value>
        public int OrderId { get; set; }

        /// <summary>
        /// 取得或設定商品項目 ID。
        /// </summary>
        /// <value>商品項目 ID。</value>
        public int ProductItemId { get; set; }

        /// <summary>
        /// 取得或設定商品項目。
        /// </summary>
        /// <value>商品項目。</value>
        public ProductItem ProductItem { get; set; }

        /// <summary>
        /// 取得或設定訂單明細商品配件的集合。
        /// </summary>
        /// <value>訂單明細商品配件的集合。</value>
        public ICollection<OrderDetailProductAccessory> ProductAccessories { get; set; }
    }
}