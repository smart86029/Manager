import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { JobTitleListComponent } from './job-title-list/job-title-list.component';

const routes: Routes = [
  { path: '', component: JobTitleListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobTitlesRoutingModule { }
