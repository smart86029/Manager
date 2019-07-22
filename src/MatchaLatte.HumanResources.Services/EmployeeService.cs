using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Queries;
using MatchaLatte.HumanResources.App.Queries.Employees;
using MatchaLatte.HumanResources.App.Services;
using MatchaLatte.HumanResources.Domain.Employees;

namespace MatchaLatte.HumanResources.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<PaginationResult<EmployeeSummary>> GetEmployeesAsync(EmployeeOption option)
        {
            var employees = await employeeRepository.GetEmployeesAsync(option.Offset, option.Limit);
            var count = await employeeRepository.GetEmployeesCountAsync();
            var result = new PaginationResult<EmployeeSummary>()
            {
                Items = employees
                    .Select(x => new EmployeeSummary
                    {
                    })
                    .ToList(),
                ItemCount = count
            };

            return result;
        }
    }
}