import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminIndexComponent } from './admin-index/admin-index.component';
import { AdminRoutingModule } from './admin-routing.module';

@NgModule({
  imports: [
    RouterModule,
    SharedModule,
    AdminRoutingModule
  ],
  declarations: [
    AdminDashboardComponent,
    AdminIndexComponent
  ]
})
export class AdminModule { }
