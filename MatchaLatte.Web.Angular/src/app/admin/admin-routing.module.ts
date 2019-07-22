import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from '../auth/auth.guard';
import { GroupDetailComponent } from '../group/group-detail/group-detail.component';
import { GroupListComponent } from '../group/group-list/group-list.component';
import { PermissionDetailComponent } from '../permission/permission-detail/permission-detail.component';
import { PermissionListComponent } from '../permission/permission-list/permission-list.component';
import { RoleDetailComponent } from '../role/role-detail/role-detail.component';
import { RoleListComponent } from '../role/role-list/role-list.component';
import { StoreDetailComponent } from '../store/store-detail/store-detail.component';
import { StoreListComponent } from '../store/store-list/store-list.component';
import { UserDetailComponent } from '../user/user-detail/user-detail.component';
import { UserListComponent } from '../user/user-list/user-list.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminIndexComponent } from './admin-index/admin-index.component';

const routes: Routes = [
  {
    path: '',
    component: AdminIndexComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: AdminDashboardComponent },
      {
        path: 'users', children: [
          { path: '', component: UserListComponent },
          { path: ':id', component: UserDetailComponent },
          { path: 'new', component: UserDetailComponent }
        ]
      },
      {
        path: 'roles', children: [
          { path: '', component: RoleListComponent },
          { path: ':id', component: RoleDetailComponent },
          { path: 'new', component: RoleDetailComponent }
        ]
      },
      {
        path: 'permissions', children: [
          { path: '', component: PermissionListComponent },
          { path: ':id', component: PermissionDetailComponent },
          { path: 'new', component: PermissionDetailComponent }
        ]
      },
      {
        path: 'stores', children: [
          { path: '', component: StoreListComponent },
          { path: ':id', component: StoreDetailComponent },
          { path: 'new', component: StoreDetailComponent }
        ]
      },
      {
        path: 'groups', children: [
          { path: '', component: GroupListComponent },
          { path: 'new', component: GroupDetailComponent },
          { path: ':id', component: GroupDetailComponent }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
