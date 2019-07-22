import { NgModule } from '@angular/core';

import { GroupModule } from '../group/group.module';
import { PermissionModule } from '../permission/permission.module';
import { RoleModule } from '../role/role.module';
import { SharedModule } from '../shared/shared.module';
import { StoreModule } from '../store/store.module';
import { UserModule } from '../user/user.module';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminIndexComponent } from './admin-index/admin-index.component';
import { AdminRoutingModule } from './admin-routing.module';

@NgModule({
  declarations: [
    AdminIndexComponent,
    AdminDashboardComponent,
  ],
  imports: [
    SharedModule,
    AdminRoutingModule,
    UserModule,
    RoleModule,
    PermissionModule,
    StoreModule,
    GroupModule,
  ]
})
export class AdminModule { }
