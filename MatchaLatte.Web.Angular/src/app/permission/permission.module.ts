import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { PermissionDetailComponent } from './permission-detail/permission-detail.component';
import { PermissionListComponent } from './permission-list/permission-list.component';

@NgModule({
  declarations: [
    PermissionDetailComponent,
    PermissionListComponent
  ],
  imports: [
    SharedModule,
  ]
})
export class PermissionModule { }
