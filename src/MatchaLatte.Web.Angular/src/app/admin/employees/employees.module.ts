import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';

@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeDetailComponent,
  ],
  imports: [
    SharedModule,
    EmployeesRoutingModule,
  ]
})
export class EmployeesModule { }
