import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { JobTitleListComponent } from './job-title-list/job-title-list.component';
import { JobTitlesRoutingModule } from './job-titles-routing.module';

@NgModule({
  declarations: [
    JobTitleListComponent,
  ],
  imports: [
    SharedModule,
    JobTitlesRoutingModule,
  ]
})
export class JobTitlesModule { }
