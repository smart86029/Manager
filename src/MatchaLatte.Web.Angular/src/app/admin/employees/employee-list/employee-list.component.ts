import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { Department } from 'src/app/core/department/department';
import { DepartmentService } from 'src/app/core/department/department.service';
import { Employee } from 'src/app/core/employee/employee';
import { EmployeeService } from 'src/app/core/employee/employee.service';
import { JobTitleService } from 'src/app/core/job-title/job-title.service';
import { PaginationResult } from 'src/app/core/pagination-result';
import { JobTitle } from 'src/app/core/job-title/job-title';
import { Guid } from 'src/app/core/guid';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, AfterViewInit {
  isLoading = true;
  employees = new PaginationResult<Employee>();
  dataSource = new MatTableDataSource<Employee>();
  displayedColumns = ['rowId', 'name', 'displayName', 'department', 'jobTitle', 'action'];
  departments: Department[];
  jobTitles: JobTitle[];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private jobTitleService: JobTitleService) { }

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe(departments => this.departments = departments);
    this.jobTitleService.getJobTitles().subscribe(jobTitles => this.jobTitles = jobTitles);
  }

  ngAfterViewInit(): void {
    from(this.paginator.page)
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.employeeService.getEmployees(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(() => this.isLoading = false)
      )
      .subscribe({
        next: employees => {
          this.employees = employees;
          this.dataSource.data = employees.items;
        },
      });
  }

  getDepartmentName(departmentId: Guid): string {
    return this.departments.find(d => d.id === departmentId).name;
  }

  getJobTitle(jobTitleId: Guid): string {
    return this.jobTitles.find(j => j.id === jobTitleId).name;
  }
}
