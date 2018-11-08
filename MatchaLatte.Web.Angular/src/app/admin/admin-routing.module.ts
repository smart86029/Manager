import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminIndexComponent } from './admin-index/admin-index.component';

const routes: Routes = [
  {
    path: '',
    component: AdminIndexComponent,
    children: [
      // { path: '', component: AdminDashboardComponent },
      { path: 'users', loadChildren: 'app/user/user.module#UserModule' },
      { path: 'roles', loadChildren: 'app/role/role.module#RoleModule' },
      { path: 'permissions', loadChildren: 'app/permission/permission.module#PermissionModule' },
      { path: 'stores', loadChildren: '../store/store.module#StoreModule' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
