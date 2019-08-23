import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeesRoutingModule } from './employees-routing.module';

@NgModule({
  declarations: [
    EmployeeListComponent,
  ],
  imports: [
    SharedModule,
    EmployeesRoutingModule,
  ]
})
export class EmployeesModule { }
