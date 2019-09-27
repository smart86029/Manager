using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.App.Users;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Buyers;

namespace MatchaLatte.Ordering.Events.Users
{
    public class UserCreatedEventHandler : IEventHandler<UserCreated>
    {
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IBuyerRepository buyerRepository;

        public UserCreatedEventHandler(IOrderingUnitOfWork unitOfWork, IBuyerRepository buyerRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
        }

        public async Task HandleAsync(UserCreated @event)
        {
            var buyer = new Buyer(@event.UserId, @event.Name, @event.DisplayName);

            buyerRepository.Add(buyer);

            await unitOfWork.CommitAsync();
        }
    }
}