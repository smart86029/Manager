using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Stores
{
    /// <summary>
    /// 店家。
    /// </summary>
    public class Store : AggregateRoot
    {
        private List<ProductCategory> productCategories = new List<ProductCategory>();

        /// <summary>
        /// 初始化 <see cref="Store"/> 類別的新執行個體。
        /// </summary>
        private Store()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Store"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="phone">電話。</param>
        /// <param name="address">地址。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">建立者 ID。</param>
        public Store(string name, string description, Picture logo, Phone phone, Address address, string remark, Guid createdBy)
        {
            Name = name;
            Description = description?.Trim();
            Logo = logo;
            Phone = phone;
            Address = address;
            Remark = remark;
            CreatedBy = createdBy;
            CreatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 取得描述。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 取得商標。
        /// </summary>
        public Picture Logo { get; private set; }

        /// <summary>
        /// 取得電話。
        /// </summary>
        public Phone Phone { get; private set; }

        /// <summary>
        /// 取得地址。
        /// </summary>
        public Address Address { get; private set; }

        /// <summary>
        /// 取得備註。
        /// </summary>
        public string Remark { get; private set; }

        /// <summary>
        /// 取得建立者 ID。
        /// </summary>
        public Guid CreatedBy { get; private set; }

        /// <summary>
        /// 取得建立時間。
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得商品分類的集合。
        /// </summary>
        /// <value>商品分類的集合。</value>
        public IReadOnlyCollection<ProductCategory> ProductCategories => productCategories;

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 更新描述。
        /// </summary>
        /// <param name="description">描述。</param>
        public void UpdateDescription(string description)
        {
            Description = description?.Trim();
        }

        /// <summary>
        /// 更新電話。
        /// </summary>
        /// <param name="phone">電話。</param>
        public void UpdatePhone(Phone phone)
        {
            Phone = phone;
        }

        /// <summary>
        /// 更新地址。
        /// </summary>
        /// <param name="address">地址。</param>
        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        /// <summary>
        /// 更新備註。
        /// </summary>
        /// <param name="remark">備註。</param>
        public void UpdateRemark(string remark)
        {
            Remark = remark;
        }

        /// <summary>
        /// 加入商品分類。
        /// </summary>
        /// <param name="name">商品分類名稱。</param>
        public void AddProductCategory(string name)
        {
            productCategories.Add(new ProductCategory(name));
        }

        /// <summary>
        /// 移除商品分類。
        /// </summary>
        /// <param name="productCategory">商品分類。</param>
        public void RemoveProductCategory(ProductCategory productCategory)
        {
            productCategories.Remove(productCategory);
        }
    }
}