using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Queries.Departments;

namespace MatchaLatte.HumanResources.App.Services
{
    public interface IDepartmentService
    {
        Task<ICollection<DepartmentSummary>> GetDepartmentsAsync();
    }
}