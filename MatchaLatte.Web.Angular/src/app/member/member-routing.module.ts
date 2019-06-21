import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberIndexComponent } from './member-index/member-index.component';

const routes: Routes = [
  {
    path: '',
    component: MemberIndexComponent,
    children: [
      { path: '', component: MemberGalleryComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
