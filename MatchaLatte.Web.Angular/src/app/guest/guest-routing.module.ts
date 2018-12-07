import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GuestGalleryComponent } from './guest-gallery/guest-gallery.component';
import { GuestIndexComponent } from './guest-index/guest-index.component';

const routes: Routes = [
  {
    path: '',
    component: GuestIndexComponent,
    children: [
      { path: '', component: GuestGalleryComponent },
      { path: 'stores', loadChildren: '../store/store.module#StoreModule' },
      { path: 'groups', loadChildren: '../group/group.module#GroupModule' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GuestRoutingModule { }
