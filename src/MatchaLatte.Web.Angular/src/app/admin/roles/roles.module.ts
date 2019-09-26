import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { RoleDetailComponent } from './role-detail/role-detail.component';
import { RoleListComponent } from './role-list/role-list.component';
import { RolesRoutingModule } from './roles-routing.module';

@NgModule({
  declarations: [
    RoleListComponent,
    RoleDetailComponent,
  ],
  imports: [
    SharedModule,
    RolesRoutingModule,
  ],
})
export class RolesModule { }
