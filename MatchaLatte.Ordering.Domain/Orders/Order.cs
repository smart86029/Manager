using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;
using MatchaLatte.Ordering.Domain.Buyers;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單。
    /// </summary>
    public class Order : AggregateRoot
    {
        private List<OrderItem> orderItems = new List<OrderItem>();

        /// <summary>
        /// 初始化 <see cref="Order"/> 類別的新執行個體。
        /// </summary>
        private Order()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Order"/> 類別的新執行個體。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <param name="buyerId">買家 ID。</param>
        public Order(Guid groupId, Guid buyerId)
        {
            GroupId = groupId;
            BuyerId = buyerId;
            RaiseDomainEvent(new OrderCreated(Id, buyerId));
        }

        /// <summary>
        /// 取得訂單狀態。
        /// </summary>
        /// <value>訂單狀態。</value>
        public OrderStatus OrderStatus { get; private set; } = OrderStatus.Created;

        /// <summary>
        /// 取得應付金額。
        /// </summary>
        /// <value>應付金額。</value>
        public decimal AmountPayable => orderItems.Sum(x => x.ProductItemPrice * x.Quantity + x.OrderItemProductAccessories.Sum(y => y.ProductAccessoryPrice));

        /// <summary>
        /// 取得實付金額。
        /// </summary>
        /// <value>實付金額。</value>
        public decimal AmountPaid { get; private set; }

        /// <summary>
        /// 取得團 ID。
        /// </summary>
        /// <value>團 ID。</value>
        public Guid GroupId { get; private set; }

        /// <summary>
        /// 取得買家 ID。
        /// </summary>
        /// <value>買家 ID。</value>
        public Guid BuyerId { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// 取得付款時間。
        /// </summary>
        /// <value>付款時間。</value>
        public DateTime? PaidOn { get; private set; }

        /// <summary>
        /// 取得是否已付款。
        /// </summary>
        /// <value>是否已付款。</value>
        public bool HasPaid => AmountPaid >= AmountPayable;

        /// <summary>
        /// 取得訂單明細的集合。
        /// </summary>
        /// <value>訂單明細的集合。</value>
        public IReadOnlyCollection<OrderItem> OrderItems => orderItems;

        /// <summary>
        /// 加入訂單項目。
        /// </summary>
        /// <param name="product">訂單項目。</param>
        public void AddOrderItem(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
        }

        /// <summary>
        /// 設定買家已確認。
        /// </summary>
        public void SetBuyerConfirmed()
        {
            if (BuyerId == default)
                throw new InvalidException();

            if (OrderStatus != OrderStatus.Created)
                throw new InvalidException();

            OrderStatus = OrderStatus.BuyerConfirmed;
        }

        /// <summary>
        /// 付款。
        /// </summary>
        /// <param name="money">金額。</param>
        public void Pay(decimal money)
        {
            AmountPaid += money;
        }
    }
}