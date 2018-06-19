import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from '../core/auth.guard';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'users', loadChildren: 'app/user/user.module#UserModule', canLoad: [AuthGuard] },
      { path: 'roles', loadChildren: 'app/role/role.module#RoleModule', canLoad: [AuthGuard] },
      { path: 'permissions', loadChildren: 'app/permission/permission.module#PermissionModule', canLoad: [AuthGuard] },
      { path: 'stores', loadChildren: 'app/store/store.module#StoreModule', canLoad: [AuthGuard] }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
