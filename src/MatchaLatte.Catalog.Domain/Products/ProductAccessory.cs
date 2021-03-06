﻿using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Products
{
    /// <summary>
    /// 商品配件。
    /// </summary>
    public class ProductAccessory : Entity
    {
        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal Price { get; set; }

        /// <summary>
        /// 取得或設定商品 ID。
        /// </summary>
        /// <value>商品 ID。</value>
        public Guid ProductId { get; set; }
    }
}