using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Orders;
using MatchaLatte.Ordering.App.Queries.Orders;
using MatchaLatte.Ordering.Domain.Buyers;
using MatchaLatte.Ordering.Domain.Orders;

namespace MatchaLatte.Ordering.Commands.Orders
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDetail>
    {
        private IBuyerRepository buyerRepository;
        private IOrderRepository orderRepository;

        public CreateOrderCommandHandler(IBuyerRepository buyerRepository, IOrderRepository orderRepository)
        {
            this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<OrderDetail> HandleAsync(CreateOrderCommand command)
        {
            var buyer = await buyerRepository.GetBuyerByUserIdAsync(command.UserId);

            //var order = new Order(command.UserId)
            var result = new OrderDetail();

            return result;
        }
    }
}
