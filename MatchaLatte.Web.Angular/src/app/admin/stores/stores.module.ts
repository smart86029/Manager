import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { StoresRoutingModule } from './stores-routing.module';

@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    StoresRoutingModule,
  ],
})
export class StoresModule { }
