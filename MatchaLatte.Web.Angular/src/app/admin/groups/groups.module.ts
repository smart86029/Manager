import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupsRoutingModule } from './groups-routing.module';

@NgModule({
  declarations: [
    GroupListComponent,
    GroupDetailComponent,
  ],
  imports: [
    SharedModule,
    GroupsRoutingModule,
  ],
})
export class GroupsModule { }
