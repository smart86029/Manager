using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.HumanResources.App.Queries.Departments;
using MatchaLatte.HumanResources.App.Services;
using MatchaLatte.HumanResources.Domain.Departments;

namespace MatchaLatte.HumanResources.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        }

        public async Task<ICollection<DepartmentSummary>> GetDepartmentsAsync()
        {
            var departments = await departmentRepository.GetDepartmentsAsync();
            var result = departments
                .Select(d => new DepartmentSummary
                {
                    Id = d.Id,
                    Name = d.Name,
                    ParentId = d.ParentId,
                })
                .ToList();

            return result;
        }
    }
}