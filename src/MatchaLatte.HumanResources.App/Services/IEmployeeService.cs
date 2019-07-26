using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Queries;
using MatchaLatte.HumanResources.App.Queries.Employees;

namespace MatchaLatte.HumanResources.App.Services
{
    public interface IEmployeeService
    {
        Task<PaginationResult<EmployeeSummary>> GetEmployeesAsync(EmployeeOption option);
    }
}