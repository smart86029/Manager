import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ProductDetailDialogComponent } from './product-detail-dialog/product-detail-dialog.component';
import { StoreDetailComponent } from './store-detail/store-detail.component';
import { StoreListComponent } from './store-list/store-list.component';

@NgModule({
  imports: [
    SharedModule,
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
