import { Component, OnInit } from '@angular/core';
import { JobTitleService } from 'src/app/core/job-title/job-title.service';
import { JobTitle } from 'src/app/core/job-title/job-title';

@Component({
  selector: 'app-job-title-list',
  templateUrl: './job-title-list.component.html',
  styleUrls: ['./job-title-list.component.scss']
})
export class JobTitleListComponent implements OnInit {
  isLoading = true;
  isEmpty = false;
  jobTitles: JobTitle[];
  displayedColumns = ['rowId', 'name', 'action'];

  constructor(private jobTitleService: JobTitleService) { }

  ngOnInit(): void {
    this.jobTitleService
      .getJobTitles()
      .subscribe({
        next: jobTitles => {
          this.jobTitles = jobTitles;
          this.isEmpty = jobTitles.length === 0;
        },
        complete: () => this.isLoading = false
      });
  }
}
