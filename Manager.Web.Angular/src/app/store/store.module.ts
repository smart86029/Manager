import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { StoreListComponent } from './store-list/store-list.component';
import { StoreRoutingModule } from './store-routing.module';
import { StoreService } from './store.service';
import { StoreDetailComponent } from './store-detail/store-detail.component';

@NgModule({
  imports: [
    SharedModule,
    StoreRoutingModule
  ],
  declarations: [
    StoreListComponent,
    StoreDetailComponent
  ],
  providers: [
    StoreService
  ]
})
export class StoreModule { }
