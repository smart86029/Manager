import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PermissionDetailComponent } from './permission-detail/permission-detail.component';
import { PermissionListComponent } from './permission-list/permission-list.component';

const routes: Routes = [
  { path: '', component: PermissionListComponent },
  { path: ':id', component: PermissionDetailComponent },
  { path: 'new', component: PermissionDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PermissionRoutingModule { }
