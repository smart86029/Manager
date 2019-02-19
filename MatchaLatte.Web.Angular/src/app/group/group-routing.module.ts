import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupJoinComponent } from './group-join/group-join.component';

const routes: Routes = [
  { path: '', component: GroupListComponent },
  { path: 'new', component: GroupDetailComponent },
  { path: ':id', component: GroupDetailComponent },
  { path: ':id/join', component: GroupJoinComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupRoutingModule { }
