import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RoleDetailComponent } from './role-detail/role-detail.component';
import { RoleListComponent } from './role-list/role-list.component';

const routes: Routes = [
  { path: '', component: RoleListComponent },
  { path: ':id', component: RoleDetailComponent },
  { path: 'new', component: RoleDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRoutingModule { }
