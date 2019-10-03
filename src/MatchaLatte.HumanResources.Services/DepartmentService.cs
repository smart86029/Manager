using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Exceptions;
using MatchaLatte.HumanResources.App.Departments;
using MatchaLatte.HumanResources.Domain;
using MatchaLatte.HumanResources.Domain.Departments;

namespace MatchaLatte.HumanResources.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IHumanResourcesUnitOfWork unitOfWork;
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IHumanResourcesUnitOfWork unitOfWork, IDepartmentRepository departmentRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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

        public async Task<Guid> CreateDepartmentAsync(CreateDepartmentCommand command)
        {
            var department = new Department(command.Name, command.IsEnabled, command.ParentId);

            departmentRepository.Add(department);
            await unitOfWork.CommitAsync();

            return department.Id;
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentCommand command)
        {
            var department = await departmentRepository.GetDepartmentAsync(command.Id) ?? throw new InvalidException("部門不存在");

            department.UpdateName(command.Name);
            departmentRepository.Update(department);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteDepartmentAsync(Guid departmentId)
        {
            var department = await departmentRepository.GetDepartmentAsync(departmentId);
            if (department == default)
                return;

            departmentRepository.Remove(department);
            await unitOfWork.CommitAsync();
        }
    }
}