import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { GroupsRoutingModule } from './groups-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    GroupsRoutingModule,
  ],
})
export class GroupsModule { }
