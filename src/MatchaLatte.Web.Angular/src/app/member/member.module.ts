import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GroupJoinComponent } from './group-join/group-join.component';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberRoutingModule } from './member-routing.module';
import { MemberComponent } from './member.component';
import { OrderDialogComponent } from './order-dialog/order-dialog.component';
import { OrderListComponent } from './order-list/order-list.component';

@NgModule({
  declarations: [
    MemberComponent,
    MemberGalleryComponent,
    GroupJoinComponent,
    OrderListComponent,
    OrderDialogComponent,
  ],
  imports: [
    SharedModule,
    MemberRoutingModule,
  ],
  entryComponents: [
    OrderDialogComponent,
  ],
})
export class MemberModule { }
