import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { ProductDetailDialogComponent } from './product-detail-dialog/product-detail-dialog.component';
import { StoreDetailComponent } from './store-detail/store-detail.component';
import { StoreListComponent } from './store-list/store-list.component';
import { StoresRoutingModule } from './stores-routing.module';

@NgModule({
  declarations: [
    StoreListComponent,
    StoreDetailComponent,
    ProductDetailDialogComponent,
  ],
  imports: [
    SharedModule,
    StoresRoutingModule,
  ],
  entryComponents: [
    ProductDetailDialogComponent,
  ],
})
export class StoresModule { }
