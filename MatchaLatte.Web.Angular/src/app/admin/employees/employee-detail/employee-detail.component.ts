import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/core/employee/employee';
import { EmployeeService } from 'src/app/core/employee/employee.service';
import { Guid } from 'src/app/core/guid';
import { SaveMode } from 'src/app/shared/save-mode/save-mode.enum';
import { Gender } from 'src/app/core/gender.enum';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  isLoading: boolean;
  saveMode = SaveMode.Create;
  employee = new Employee();
  gender = Gender;

  constructor(private employeeService: EmployeeService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.isLoading = true;
      this.saveMode = SaveMode.Update;
      this.employeeService
        .getEmployee(new Guid(id))
        .subscribe({
          next: employee => this.employee = employee,
          complete: () => this.isLoading = false
        });
    }
  }

  save(): void {
  }

  back(): void {
    this.location.back();
  }
}
