import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
import { Department } from 'src/app/core/department/department';
import { DepartmentService } from 'src/app/core/department/department.service';
import { Employee } from 'src/app/core/employee/employee';
import { EmployeeService } from 'src/app/core/employee/employee.service';
import { Guid } from 'src/app/core/guid';
import { JobTitle } from 'src/app/core/job-title/job-title';
import { JobTitleService } from 'src/app/core/job-title/job-title.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, AfterViewInit, OnDestroy {
  isLoading = true;
  isEmptyResult = false;
  employees = new PaginationResult<Employee>();
  dataSource = new MatTableDataSource<Employee>();
  displayedColumns = ['rowId', 'name', 'displayName', 'department', 'jobTitle', 'action'];
  departments: Department[];
  jobTitles: JobTitle[];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private jobTitleService: JobTitleService) { }

  ngOnInit(): void {
    this.departmentService
      .getDepartments()
      .pipe(
        tap(departments => this.departments = departments)
      )
      .subscribe();
    this.jobTitleService
      .getJobTitles()
      .pipe(
        tap(jobTitles => this.jobTitles = jobTitles)
      )
      .subscribe();
  }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.employeeService.getEmployees(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(employees => {
          this.isLoading = false;
          this.isEmptyResult = employees.itemCount === 0;
          this.employees = employees;
          this.dataSource.data = employees.items;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getDepartmentName(departmentId: Guid): string {
    return this.departments.find(d => d.id === departmentId).name;
  }

  getJobTitle(jobTitleId: Guid): string {
    return this.jobTitles.find(j => j.id === jobTitleId).name;
  }
}
