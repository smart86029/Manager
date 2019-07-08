import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupJoinComponent } from '../member/group-join/group-join.component';
import { GroupListComponent } from './group-list/group-list.component';

const routes: Routes = [
  { path: '', component: GroupListComponent },
  { path: 'new', component: GroupDetailComponent },
  { path: ':id', component: GroupDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupRoutingModule { }
