import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { DepartmentDetailDialogComponent } from './department-detail-dialog/department-detail-dialog.component';
import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentsRoutingModule } from './departments-routing.module';

@NgModule({
  declarations: [
    DepartmentListComponent,
    DepartmentDetailDialogComponent,
  ],
  imports: [
    SharedModule,
    DepartmentsRoutingModule,
  ],
  entryComponents: [
    DepartmentDetailDialogComponent,
  ]
})
export class DepartmentsModule { }
