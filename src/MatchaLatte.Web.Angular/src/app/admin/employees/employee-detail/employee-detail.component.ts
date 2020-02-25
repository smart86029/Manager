import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { finalize, tap } from 'rxjs/operators';
import { Department } from 'src/app/core/department/department';
import { DepartmentService } from 'src/app/core/department/department.service';
import { Employee } from 'src/app/core/employee/employee';
import { EmployeeService } from 'src/app/core/employee/employee.service';
import { Gender } from 'src/app/core/gender.enum';
import { Guid } from 'src/app/core/guid';
import { JobTitle } from 'src/app/core/job-title/job-title';
import { JobTitleService } from 'src/app/core/job-title/job-title.service';
import { MaritalStatus } from 'src/app/core/marital-status.enum';
import { SaveMode } from 'src/app/core/save-mode.enum';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  isLoading = true;
  saveMode = SaveMode.Create;
  employee = new Employee();
  departments: Department[];
  jobTitles: JobTitle[];
  gender = Gender;
  maritalStatus = MaritalStatus;
  canAssignJob = true;
  now = new Date();

  constructor(
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private jobTitleService: JobTitleService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    let employee$ = of(this.employee);
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      this.canAssignJob = false;
      employee$ = this.employeeService.getEmployee(new Guid(id));
    }
    forkJoin([employee$, this.departmentService.getDepartments(), this.jobTitleService.getJobTitles()])
      .pipe(
        tap(([employee, departments, jobTitles]) => {
          this.employee = employee;
          this.departments = departments;
          this.jobTitles = jobTitles;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe();
  }

  save(): void {
    let employee$ = this.employeeService.createEmployee(this.employee);
    if (this.saveMode === SaveMode.Update) {
      employee$ = this.employeeService.updateEmployee(this.employee);
    }
    employee$
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
  }

  back(): void {
    this.location.back();
  }
}
