import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { PermissionDetailComponent } from './permission-detail/permission-detail.component';
import { PermissionListComponent } from './permission-list/permission-list.component';
import { PermissionRoutingModule } from './permission-routing.module';

@NgModule({
  imports: [
    SharedModule,
    PermissionRoutingModule
  ],
  declarations: [
    PermissionDetailComponent,
    PermissionListComponent
  ]
})
export class PermissionModule { }
