import { NgModule } from '@angular/core';

import { GroupModule } from '../group/group.module';
import { SharedModule } from '../shared/shared.module';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberIndexComponent } from './member-index/member-index.component';
import { MemberRoutingModule } from './member-routing.module';

@NgModule({
  declarations: [
    MemberIndexComponent,
    MemberGalleryComponent,
  ],
  imports: [
    SharedModule,
    MemberRoutingModule,
    GroupModule,
  ],
  entryComponents: [
  ]
})
export class MemberModule { }
