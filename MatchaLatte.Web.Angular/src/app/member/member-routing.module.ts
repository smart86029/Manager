import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GroupJoinComponent } from '../group/group-join/group-join.component';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberIndexComponent } from './member-index/member-index.component';

const routes: Routes = [
  {
    path: '',
    component: MemberIndexComponent,
    children: [
      { path: '', component: MemberGalleryComponent },
      { path: 'groups/:id/join', component: GroupJoinComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
