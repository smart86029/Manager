using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Ordering.Domain.Stores
{
    /// <summary>
    /// 店家。
    /// </summary>
    public class Store : Entity, IAggregateRoot
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
        /// <param name="createdBy">新增者 ID。</param>
        public Store(string name, string description, Phone phone, Address address, string remark, Guid createdBy)
            : this(GuidUtility.NewGuid(), name, description, phone, address, remark, createdBy)
        {
        }

        /// <summary>
        /// 初始化 <see cref="Store"/> 類別的新執行個體。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="phone">電話。</param>
        /// <param name="address">地址。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">新增者 ID。</param>
        public Store(Guid storeId, string name, string description, Phone phone, Address address, string remark, Guid createdBy)
        {
            StoreId = storeId;
            Name = name;
            Description = description;
            Phone = phone;
            Address = address;
            Remark = remark;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            productCategories.Add(new ProductCategory("Default", true));
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid StoreId { get; private set; }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; private set; }

        /// <summary>
        /// 取得電話。
        /// </summary>
        /// <value>電話。</value>
        public Phone Phone { get; private set; }

        /// <summary>
        /// 取得地址。
        /// </summary>
        /// <value>地址。</value>
        public Address Address { get; private set; }

        /// <summary>
        /// 取得備註。
        /// </summary>
        /// <value>備註。</value>
        public string Remark { get; private set; }

        /// <summary>
        /// 取得新增者 ID。
        /// </summary>
        /// <value>新增者 ID。</value>
        public Guid CreatedBy { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得商品分類的集合。
        /// </summary>
        /// <value>商品分類。</value>
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
            Description = description;
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
        /// <param name="productCategory">商品分類。</param>
        public void AddProductCategory(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }
    }
}