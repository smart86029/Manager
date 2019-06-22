import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupRoutingModule } from './group-routing.module';

@NgModule({
  declarations: [
    GroupListComponent,
    GroupDetailComponent,
  ],
  imports: [
    SharedModule,
    GroupRoutingModule
  ]
})
export class GroupModule { }
