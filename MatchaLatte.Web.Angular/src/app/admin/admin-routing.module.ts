import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from '../auth/auth.guard';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminComponent } from './admin.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: AdminDashboardComponent
      },
      {
        path: 'users',
        loadChildren: () => import('./users/users.module').then(mod => mod.UsersModule)
      },
      {
        path: 'roles',
        loadChildren: () => import('./roles/roles.module').then(mod => mod.RolesModule)
      },
      {
        path: 'permissions',
        loadChildren: () => import('./permissions/permissions.module').then(mod => mod.PermissionsModule)
      },
      {
        path: 'employees',
        loadChildren: () => import('./employees/employees.module').then(mod => mod.EmployeesModule),
        data: {
          permissions: ['HumanResources']
        }
      },
      {
        path: 'departments',
        loadChildren: () => import('./departments/departments.module').then(mod => mod.DepartmentsModule),
        data: {
          permissions: ['HumanResources']
        }
      },
      {
        path: 'job-titles',
        loadChildren: () => import('./job-titles/job-titles.module').then(mod => mod.JobTitlesModule),
        data: {
          permissions: ['HumanResources']
        }
      },
      {
        path: 'stores',
        loadChildren: () => import('./stores/stores.module').then(mod => mod.StoresModule)
      },
      {
        path: 'groups',
        loadChildren: () => import('./groups/groups.module').then(mod => mod.GroupsModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
