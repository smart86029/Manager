import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { RoleRoutingModule } from './role-routing.module';
import { RoleService } from './role.service';
import { RoleListComponent } from './role-list/role-list.component';
import { RoleDetailComponent } from './role-detail/role-detail.component';

@NgModule({
  imports: [
    SharedModule,
    RoleRoutingModule
  ],
  declarations: [
    RoleListComponent,
    RoleDetailComponent
  ],
  providers: [
    RoleService
  ]
})
export class RoleModule { }
