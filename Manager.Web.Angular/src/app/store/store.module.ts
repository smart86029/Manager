import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreRoutingModule } from './store-routing.module';
import { StoreListComponent } from './store-list/store-list.component';

@NgModule({
  imports: [
    CommonModule,
    StoreRoutingModule
  ],
  declarations: [StoreListComponent]
})
export class StoreModule { }
