import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';

@NgModule({
  declarations: [
    AdminComponent,
    AdminDashboardComponent,
  ],
  imports: [
    SharedModule,
    AdminRoutingModule,
  ]
})
export class AdminModule { }
