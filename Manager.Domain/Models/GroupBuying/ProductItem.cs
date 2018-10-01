using Manager.Domain.Exceptions;

namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 商品項目。
    /// </summary>
    public class ProductItem : Entity
    {
        /// <summary>
        /// 初始化 <see cref="ProductItem"/> 類別的新執行個體。
        /// </summary>
        private ProductItem()
        {
        }

        /// <summary>
        /// 初始化 <see cref="ProductItem"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="price">價格。</param>
        public ProductItem(string name, decimal price)
        {
            if (price < 0)
                throw new InvalidException();

            Name = name;
            Price = price;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductItemId { get; private set; }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal Price { get; private set; }

        /// <summary>
        /// 取得商品 ID。
        /// </summary>
        /// <value>商品 ID。</value>
        public int ProductId { get; private set; }

        /// <summary>
        /// 取得商品。
        /// </summary>
        /// <value>商品。</value>
        public Product Product { get; private set; }

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 更新價格。
        /// </summary>
        /// <param name="price">價格。</param>
        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
    }
}