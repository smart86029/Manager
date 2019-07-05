using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Orders;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Orders;

namespace MatchaLatte.Ordering.Commands.Orders
{
    public class ConfirmBuyerCommandHandler : ICommandHandler<ConfirmBuyerCommand, bool>
    {
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IOrderRepository orderRepository;

        public ConfirmBuyerCommandHandler(IOrderingUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<bool> HandleAsync(ConfirmBuyerCommand command)
        {
            var order = await orderRepository.GetOrderAsync(command.Id);
            order.SetBuyerConfirmed();

            return await unitOfWork.CommitAsync();
        }
    }
}