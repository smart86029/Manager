import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { StoreListComponent } from './store-list/store-list.component';
import { StoreRoutingModule } from './store-routing.module';
import { StoreService } from './store.service';

@NgModule({
  imports: [
    SharedModule,
    StoreRoutingModule
  ],
  declarations: [
    StoreListComponent
  ],
  providers: [
    StoreService
  ]
})
export class StoreModule { }
