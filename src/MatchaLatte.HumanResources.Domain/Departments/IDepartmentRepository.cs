using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.HumanResources.Domain.Departments
{
    /// <summary>
    /// 部門存放庫。
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// 取得部門的集合。
        /// </summary>
        /// <returns>部門的集合。</returns>
        Task<ICollection<Department>> GetDepartmentsAsync();
    }
}