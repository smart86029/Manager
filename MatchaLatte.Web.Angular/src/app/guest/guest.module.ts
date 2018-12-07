import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { GuestGalleryComponent } from './guest-gallery/guest-gallery.component';
import { GuestIndexComponent } from './guest-index/guest-index.component';
import { GuestRoutingModule } from './guest-routing.module';

@NgModule({
  declarations: [
    GuestIndexComponent,
    GuestGalleryComponent
  ],
  imports: [
    SharedModule,
    GuestRoutingModule
  ]
})
export class GuestModule { }
