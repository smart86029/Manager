import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, Observable, of } from 'rxjs';
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
  isLoading: boolean;
  saveMode = SaveMode.Create;
  employee = new Employee();
  departments: Department[];
  jobTitles: JobTitle[];
  gender = Gender;
  maritalStatus = MaritalStatus;
  canAssignJob = false;
  now = new Date();

  constructor(
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private jobTitleService: JobTitleService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit() {
    let employee$: Observable<Employee>;
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.isLoading = true;
      this.saveMode = SaveMode.Update;
      employee$ = this.employeeService.getEmployee(new Guid(id));
    } else {
      employee$ = of(this.employee);
      this.canAssignJob = true;
    }

    forkJoin(this.departmentService.getDepartments(), this.jobTitleService.getJobTitles(), employee$).subscribe({
      next: result => {
        this.departments = result[0];
        this.jobTitles = result[1];
        this.employee = result[2];
      },
      complete: () => this.isLoading = false
    });
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  private create(): void {
    this.employeeService
      .createEmployee(this.employee)
      .subscribe(employee => this.back());
  }

  private update(): void {
    this.employeeService
      .updateEmployee(this.employee)
      .subscribe(employee => this.back());
  }
}
