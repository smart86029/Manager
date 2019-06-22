import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GroupJoinComponent } from './group-join/group-join.component';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberIndexComponent } from './member-index/member-index.component';
import { MemberRoutingModule } from './member-routing.module';
import { OrderDialogComponent } from './order-dialog/order-dialog.component';

@NgModule({
  declarations: [
    MemberIndexComponent,
    MemberGalleryComponent,
    GroupJoinComponent,
    OrderDialogComponent
  ],
  imports: [
    SharedModule,
    MemberRoutingModule
  ],
  entryComponents: [
    OrderDialogComponent
  ]
})
export class MemberModule { }
