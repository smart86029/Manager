import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { RoleDetailComponent } from './role-detail/role-detail.component';
import { RoleListComponent } from './role-list/role-list.component';

@NgModule({
  declarations: [
    RoleDetailComponent,
    RoleListComponent
  ],
  imports: [
    SharedModule,
  ]
})
export class RoleModule { }
