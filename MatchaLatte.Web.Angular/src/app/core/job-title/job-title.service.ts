import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { JobTitle } from './job-title';

@Injectable({
  providedIn: 'root'
})
export class JobTitleService {
  private jobTitleUrl = 'humanResources/api/jobTitles';

  constructor(private httpClient: HttpClient) { }

  getJobTitles(): Observable<JobTitle[]> {
    return this.httpClient.get<JobTitle[]>(this.jobTitleUrl);
  }
}
