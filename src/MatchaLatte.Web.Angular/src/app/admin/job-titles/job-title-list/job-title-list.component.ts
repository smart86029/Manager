import { Component, OnInit } from '@angular/core';
import { finalize, tap } from 'rxjs/operators';
import { JobTitle } from 'src/app/core/job-title/job-title';
import { JobTitleService } from 'src/app/core/job-title/job-title.service';

@Component({
  selector: 'app-job-title-list',
  templateUrl: './job-title-list.component.html',
  styleUrls: ['./job-title-list.component.scss']
})
export class JobTitleListComponent implements OnInit {
  isLoading = true;
  isEmptyResult = false;
  jobTitles: JobTitle[];
  displayedColumns = ['rowId', 'name', 'action'];

  constructor(private jobTitleService: JobTitleService) { }

  ngOnInit(): void {
    this.jobTitleService
      .getJobTitles()
      .pipe(
        tap(jobTitles => {
          this.jobTitles = jobTitles;
          this.isEmptyResult = jobTitles.length === 0;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe();
  }
}
