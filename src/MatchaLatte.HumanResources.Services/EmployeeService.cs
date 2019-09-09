using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Queries;
using MatchaLatte.HumanResources.App.Employees;
using MatchaLatte.HumanResources.Domain;
using MatchaLatte.HumanResources.Domain.Departments;
using MatchaLatte.HumanResources.Domain.Employees;
using MatchaLatte.HumanResources.Domain.JobTitles;

namespace MatchaLatte.HumanResources.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHumanResourcesUnitOfWork unitOfWork;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IJobTitleRepository jobTitleRepository;

        public EmployeeService(
            IHumanResourcesUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IJobTitleRepository jobTitleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            this.departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            this.jobTitleRepository = jobTitleRepository ?? throw new ArgumentNullException(nameof(jobTitleRepository));
        }

        public async Task<PaginationResult<EmployeeSummary>> GetEmployeesAsync(EmployeeOption option)
        {
            var employees = await employeeRepository.GetEmployeesAsync(option.Offset, option.Limit);
            var count = await employeeRepository.GetEmployeesCountAsync();
            var departments = await departmentRepository.GetDepartmentsAsync();
            var result = new PaginationResult<EmployeeSummary>
            {
                Items = employees
                    .Select(e => new EmployeeSummary
                    {
                        Id = e.Id,
                        Name = e.Name,
                        DisplayName = e.DisplayName,
                        DepartmentId = e.DepartmentId,
                        JobTitleId = e.JobTitleId,
                    })
                    .ToList(),
                ItemCount = count
            };

            return result;
        }

        public async Task<EmployeeDetail> GetEmployeeAsync(Guid employeeId)
        {
            var employee = await employeeRepository.GetEmployeeAsync(employeeId);
            var result = new EmployeeDetail
            {
                Id = employee.Id,
                Name = employee.Name,
                DisplayName = employee.DisplayName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                MaritalStatus = employee.MaritalStatus,
            };

            return result;
        }

        public async Task<EmployeeDetail> CreateEmployeeAsync(CreateEmployeeCommand command)
        {
            var employee = new Employee(command.Name, command.DisplayName, command.BirthDate, command.Gender, command.MaritalStatus);
            var department = await departmentRepository.GetDepartmentAsync(command.DepartmentId) ?? throw new ArgumentException(nameof(command.DepartmentId));
            var jobTitle = await jobTitleRepository.GetJobTitleAsync(command.JobTitleId) ?? throw new ArgumentException(nameof(command.JobTitleId));
            employee.AssignJob(department, jobTitle, command.StartOn);

            employeeRepository.Add(employee);
            await unitOfWork.CommitAsync();

            var result = new EmployeeDetail
            {
                Id = employee.Id,
                Name = employee.Name,
                DisplayName = employee.DisplayName,
            };

            return result;
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeCommand command)
        {
            var employee =  await employeeRepository.GetEmployeeAsync(command.Id) ?? throw new ArgumentException(nameof(command.Id));

            employee.UpdateName(command.Name);
            employee.UpdateDisplayName(command.DisplayName);
            employee.UpdateBirthDate(command.BirthDate);
            employee.UpdateGender(command.Gender);
            employee.UpdateMaritalStatus(command.MaritalStatus);

            employeeRepository.Update(employee);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}