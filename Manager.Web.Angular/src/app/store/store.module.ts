import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ProductDetailDialogComponent } from './product-detail-dialog/product-detail-dialog.component';
import { StoreDetailComponent } from './store-detail/store-detail.component';
import { StoreListComponent } from './store-list/store-list.component';
import { StoreRoutingModule } from './store-routing.module';

@NgModule({
  imports: [
    SharedModule,
    StoreRoutingModule
  ],
  declarations: [
    StoreDetailComponent,
    StoreListComponent,
    ProductDetailDialogComponent
  ],
  entryComponents: [
    ProductDetailDialogComponent
  ]
})
export class StoreModule { }
