import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Guid } from '../guid';
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

  getJobTitle(id: Guid): Observable<JobTitle> {
    return this.httpClient.get<JobTitle>(`${this.jobTitleUrl}/${id}`);
  }

  createJobTitle(jobTitle: JobTitle): Observable<JobTitle> {
    return this.httpClient.post<JobTitle>(`${this.jobTitleUrl}`, jobTitle);
  }

  updateJobTitle(jobTitle: JobTitle): Observable<JobTitle> {
    return this.httpClient.put<JobTitle>(`${this.jobTitleUrl}/${jobTitle.id}`, jobTitle);
  }
}
