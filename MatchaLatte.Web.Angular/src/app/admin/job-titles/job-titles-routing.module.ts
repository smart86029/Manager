import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { JobTitleDetailComponent } from './job-title-detail/job-title-detail.component';
import { JobTitleListComponent } from './job-title-list/job-title-list.component';

const routes: Routes = [
  { path: '', component: JobTitleListComponent },
  { path: ':id', component: JobTitleDetailComponent },
  { path: 'new', component: JobTitleDetailComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobTitlesRoutingModule { }
