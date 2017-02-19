import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard.component';
import { RolesComponent } from './roles/roles.component';
import { RoleDetailComponent } from './roles/role-detail.component';
import { UserListComponent } from './users/user-list.component';

const routes: Routes = [
  //{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'roles/detail/:id', component: RoleDetailComponent },
  { path: 'roles', component: RolesComponent },
  { path: 'users', component: UserListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }