using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.App.Commands.Orders;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Buyers;
using MatchaLatte.Ordering.Domain.Orders;

namespace MatchaLatte.Ordering.App.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreated>
    {
        private readonly ICommandService commandService;
        private readonly IEventBus eventBus;
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IBuyerRepository buyerRepository;

        public OrderCreatedEventHandler(ICommandService commandService, IEventBus eventBus, IOrderingUnitOfWork unitOfWork, IBuyerRepository buyerRepository)
        {
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
        }

        public async Task HandleAsync(OrderCreated @event)
        {
            var buyer = await buyerRepository.GetBuyerAsync(@event.BuyerId);
            var existed = buyer != default(Buyer);

            if (!existed)
            {
                //await eventBus.PublishAsync(new GetUser { }
                return;
            }

            buyerRepository.Update(buyer);
            await unitOfWork.CommitAsync();

            var command = new ConfirmBuyerCommand();
            await commandService.ExecuteAsync(command);
        }
    }
}