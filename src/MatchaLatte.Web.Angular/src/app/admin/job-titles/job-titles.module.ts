import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { JobTitleListComponent } from './job-title-list/job-title-list.component';
import { JobTitlesRoutingModule } from './job-titles-routing.module';
import { JobTitleDetailComponent } from './job-title-detail/job-title-detail.component';

@NgModule({
  declarations: [
    JobTitleListComponent,
    JobTitleDetailComponent,
  ],
  imports: [
    SharedModule,
    JobTitlesRoutingModule,
  ]
})
export class JobTitlesModule { }
