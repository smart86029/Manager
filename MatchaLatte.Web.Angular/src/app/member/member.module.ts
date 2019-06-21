import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { MemberIndexComponent } from './member-index/member-index.component';
import { MemberRoutingModule } from './member-routing.module';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';

@NgModule({
  declarations: [
    MemberIndexComponent,
    MemberGalleryComponent
  ],
  imports: [
    SharedModule,
    MemberRoutingModule
  ]
})
export class MemberModule { }
