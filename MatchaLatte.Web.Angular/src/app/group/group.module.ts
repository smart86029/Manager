import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupRoutingModule } from './group-routing.module';
import { GroupJoinComponent } from './group-join/group-join.component';
import { OrderDialogComponent } from './order-dialog/order-dialog.component';

@NgModule({
  declarations: [
    GroupListComponent,
    GroupDetailComponent,
    GroupJoinComponent,
    OrderDialogComponent
  ],
  imports: [
    SharedModule,
    GroupRoutingModule
  ],
  entryComponents: [
    OrderDialogComponent
  ]
})
export class GroupModule { }
