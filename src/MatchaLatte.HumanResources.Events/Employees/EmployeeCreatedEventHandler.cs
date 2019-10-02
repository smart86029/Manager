using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Events;
using MatchaLatte.HumanResources.Domain;
using MatchaLatte.HumanResources.Domain.Employees;

namespace MatchaLatte.HumanResources.Events.Employees
{
    public class EmployeeCreatedEventHandler : IEventHandler<EmployeeCreated>
    {
        private readonly IHumanResourcesUnitOfWork unitOfWork;

        public EmployeeCreatedEventHandler(IHumanResourcesUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task HandleAsync(EmployeeCreated @event)
        {
            await Task.CompletedTask;
        }
    }
}