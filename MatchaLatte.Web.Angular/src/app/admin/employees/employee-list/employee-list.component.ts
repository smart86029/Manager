import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from 'src/app/core/employee/employee';
import { EmployeeService } from 'src/app/core/employee/employee.service';
import { PaginationResult } from 'src/app/core/pagination-result';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  isLoading = false;
  employees = new PaginationResult<Employee>();
  dataSource = new MatTableDataSource<Employee>();
  displayedColumns = ['rowId', 'name', 'displayName', 'action'];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loadEmployees(0, this.employees.pageSize);
  }

  loadEmployees(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.employeeService
      .getEmployees(pageIndex, pageSize)
      .subscribe({
        next: employees => {
          this.employees = employees;
          this.dataSource.data = employees.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
