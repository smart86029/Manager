using System.Threading.Tasks;
using MatchaLatte.Common.Queries;

namespace MatchaLatte.HumanResources.App.Employees
{
    public interface IEmployeeService
    {
        Task<PaginationResult<EmployeeSummary>> GetEmployeesAsync(EmployeeOption option);

        Task<EmployeeDetail> CreateEmployeeAsync(CreateEmployeeCommand command);
    }
}