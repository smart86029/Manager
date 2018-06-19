import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PermissionListComponent } from './permission-list/permission-list.component';

const routes: Routes = [
  { path: '', component: PermissionListComponent },
  // { path: ':id', component: RoleDetailComponent },
  // { path: 'new', component: RoleDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PermissionRoutingModule { }
