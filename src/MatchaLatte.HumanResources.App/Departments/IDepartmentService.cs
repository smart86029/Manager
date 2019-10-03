using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.HumanResources.App.Departments
{
    /// <summary>
    /// 部門服務。
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// 取得部門的集合。
        /// </summary>
        /// <returns>部門的集合。</returns>
        Task<ICollection<DepartmentSummary>> GetDepartmentsAsync();

        /// <summary>
        /// 建立部門。
        /// </summary>
        /// <param name="command">建立部門命令。</param>
        /// <returns>部門 ID。</returns>
        Task<Guid> CreateDepartmentAsync(CreateDepartmentCommand command);

        /// <summary>
        /// 更新部門。
        /// </summary>
        /// <param name="command">更新部門命令。</param>
        Task UpdateDepartmentAsync(UpdateDepartmentCommand command);

        /// <summary>
        /// 刪除部門。
        /// </summary>
        /// <param name="departmentId">部門 ID。</param>
        Task DeleteDepartmentAsync(Guid departmentId);
    }
}