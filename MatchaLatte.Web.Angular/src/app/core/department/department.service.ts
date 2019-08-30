import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Department } from './department';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private departmentsUrl = 'humanResources/api/departments';

  constructor(private httpClient: HttpClient) { }

  getDepartments(): Observable<Department[]> {
    return this.httpClient
      .get<Department[]>(this.departmentsUrl)
      .pipe(
        tap(departments => {
          departments.forEach(department => {
            if (!department.children) {
              department.children = [];
            }
          });
        })
      );
  }
}
