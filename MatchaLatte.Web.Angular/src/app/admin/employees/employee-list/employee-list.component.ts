import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { from } from 'rxjs';
import { startWith, switchMap, tap } from 'rxjs/operators';
import { Employee } from 'src/app/core/employee/employee';
import { EmployeeService } from 'src/app/core/employee/employee.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, AfterViewInit {
  isLoading = true;
  employees = new PaginationResult<Employee>();
  dataSource = new MatTableDataSource<Employee>();
  displayedColumns = ['rowId', 'name', 'displayName', 'action'];

  @ViewChild(MatPaginator, { static: false })
  paginator: MatPaginator;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
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
}
