import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentsRoutingModule } from './departments-routing.module';

@NgModule({
  declarations: [DepartmentListComponent],
  imports: [
    SharedModule,
    DepartmentsRoutingModule
  ]
})
export class DepartmentsModule { }
