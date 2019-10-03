using System;
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

        /// <summary>
        /// 取得部門。
        /// </summary>
        /// <returns>部門。</returns>
        Task<Department> GetDepartmentAsync(Guid departmentId);

        /// <summary>
        /// 加入部門。
        /// </summary>
        /// <param name="department">部門。</param>
        void Add(Department department);

        /// <summary>
        /// 更新部門。
        /// </summary>
        /// <param name="department">部門。</param>
        void Update(Department department);

        /// <summary>
        /// 移除部門。
        /// </summary>
        /// <param name="department">部門。</param>
        void Remove(Department department);
    }
}