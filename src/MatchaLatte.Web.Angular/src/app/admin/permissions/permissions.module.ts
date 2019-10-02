import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { PermissionsRoutingModule } from './permissions-routing.module';
import { PermissionListComponent } from './permission-list/permission-list.component';
import { PermissionDetailComponent } from './permission-detail/permission-detail.component';

@NgModule({
  declarations: [
    PermissionListComponent,
    PermissionDetailComponent,
  ],
  imports: [
    SharedModule,
    PermissionsRoutingModule,
  ]
})
export class PermissionsModule { }
