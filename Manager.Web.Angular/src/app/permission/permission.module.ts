import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { PermissionListComponent } from './permission-list/permission-list.component';
import { PermissionRoutingModule } from './permission-routing.module';

@NgModule({
  imports: [
    SharedModule,
    PermissionRoutingModule
  ],
  declarations: [
    PermissionListComponent
  ]
})
export class PermissionModule { }
