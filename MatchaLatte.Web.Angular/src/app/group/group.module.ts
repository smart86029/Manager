import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupRoutingModule } from './group-routing.module';
import { GroupJoinComponent } from './group-join/group-join.component';

@NgModule({
  declarations: [
    GroupListComponent,
    GroupDetailComponent,
    GroupJoinComponent
  ],
  imports: [
    SharedModule,
    GroupRoutingModule
  ]
})
export class GroupModule { }
