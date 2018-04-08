import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StoreDetailComponent } from './store-detail/store-detail.component';
import { StoreListComponent } from './store-list/store-list.component';

const routes: Routes = [
  { path: '', component: StoreListComponent },
  { path: ':id', component: StoreDetailComponent },
  { path: 'new', component: StoreDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoreRoutingModule { }
