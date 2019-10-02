import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'src/app/core/guid';
import { JobTitle } from 'src/app/core/job-title/job-title';
import { JobTitleService } from 'src/app/core/job-title/job-title.service';
import { SaveMode } from 'src/app/core/save-mode.enum';

@Component({
  selector: 'app-job-title-detail',
  templateUrl: './job-title-detail.component.html',
  styleUrls: ['./job-title-detail.component.scss']
})
export class JobTitleDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  jobTitle = new JobTitle();

  constructor(private jobTitleService: JobTitleService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.isLoading = true;
      this.saveMode = SaveMode.Update;
      this.jobTitleService.getJobTitle(new Guid(id)).subscribe({
        next: jobTitle => {
          this.jobTitle = jobTitle;
        },
        complete: () => this.isLoading = false
      });
    }
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  private create(): void {
    this.jobTitleService
      .createJobTitle(this.jobTitle)
      .subscribe(jobTitle => this.back());
  }

  private update(): void {
    this.jobTitleService
      .updateJobTitle(this.jobTitle)
      .subscribe(jobTitle => this.back());
  }
}
