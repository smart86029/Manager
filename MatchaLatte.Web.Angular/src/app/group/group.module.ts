import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupJoinComponent } from './group-join/group-join.component';
import { GroupListComponent } from './group-list/group-list.component';
import { OrderDialogComponent } from './order-dialog/order-dialog.component';

@NgModule({
  declarations: [
    GroupListComponent,
    GroupDetailComponent,
    GroupJoinComponent,
    OrderDialogComponent,
  ],
  imports: [
    SharedModule,
  ],
  entryComponents: [
    OrderDialogComponent,
  ]
})
export class GroupModule { }
