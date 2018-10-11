using System.Threading.Tasks;
using Manager.Common.Utilities;
using Manager.Domain;
using Manager.Domain.Models.System;

namespace Manager.App.DomainEventHandlers.System
{
    public class UserCreatedDomainEventHandler : IDomainEventHandler<UserCreated>
    {
        public Task Handle()
        {
            LogUtility.Debug("A");

            return Task.CompletedTask;
        }
    }
}