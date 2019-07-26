using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Orders;
using MatchaLatte.Ordering.App.Queries.Orders;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Orders;

namespace MatchaLatte.Ordering.Commands.Orders
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDetail>
    {
        private IOrderingUnitOfWork unitOfWork;
        private IOrderRepository orderRepository;

        public CreateOrderCommandHandler(IOrderingUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<OrderDetail> HandleAsync(CreateOrderCommand command)
        {
            var order = new Order(command.GroupId, command.UserId);

            foreach (var i in command.OrderItems)
                order.AddOrderItem(i.ProductId, i.ProductName, i.ProductItemId, i.ProductItemName, i.ProductItemPrice, i.Quantity);

            order.Create();
            orderRepository.Add(order);
            await unitOfWork.CommitAsync();

            var result = new OrderDetail
            {
                Id = order.Id
            };

            return result;
        }
    }
}