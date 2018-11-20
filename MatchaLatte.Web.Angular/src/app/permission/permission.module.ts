import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { PermissionDetailComponent } from './permission-detail/permission-detail.component';
import { PermissionListComponent } from './permission-list/permission-list.component';
import { PermissionRoutingModule } from './permission-routing.module';

@NgModule({
  declarations: [
    PermissionDetailComponent,
    PermissionListComponent
  ],
  imports: [
    SharedModule,
    PermissionRoutingModule
  ]
})
export class PermissionModule { }
