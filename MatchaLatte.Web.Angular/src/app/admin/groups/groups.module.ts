import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupsRoutingModule } from './groups-routing.module';
import { OrderListComponent } from './order-list/order-list.component';

@NgModule({
  declarations: [
    GroupListComponent,
    GroupDetailComponent,
    OrderListComponent,
  ],
  imports: [
    SharedModule,
    GroupsRoutingModule,
  ],
})
export class GroupsModule { }
