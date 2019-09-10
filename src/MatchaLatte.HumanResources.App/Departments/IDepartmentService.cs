using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.HumanResources.App.Departments
{
    public interface IDepartmentService
    {
        Task<ICollection<DepartmentSummary>> GetDepartmentsAsync();
    }
}