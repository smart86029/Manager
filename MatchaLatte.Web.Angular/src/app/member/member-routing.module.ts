import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GroupJoinComponent } from './group-join/group-join.component';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberComponent } from './member.component';
import { OrderListComponent } from './order-list/order-list.component';

const routes: Routes = [
  {
    path: '',
    component: MemberComponent,
    children: [
      { path: '', component: MemberGalleryComponent },
      { path: 'groups/:id/join', component: GroupJoinComponent },
      { path: 'orders', component: OrderListComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
