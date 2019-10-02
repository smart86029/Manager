import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { PaginationResult } from '../pagination-result';
import { Employee } from './employee';
import { Guid } from '../guid';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeesUrl = 'humanResources/api/employees';

  constructor(private httpClient: HttpClient) { }

  getEmployees(pageIndex: number, pageSize: number): Observable<PaginationResult<Employee>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient
      .get<Employee[]>(this.employeesUrl, { params, observe: 'response' })
      .pipe(
        map(response => {
          const itemCount = +response.headers.get('X-Total-Count');
          return new PaginationResult<Employee>(pageIndex, pageSize, itemCount, response.body);
        })
      );
  }

  getEmployee(id: Guid): Observable<Employee> {
    return this.httpClient.get<Employee>(`${this.employeesUrl}/${id}`);
  }

  createEmployee(employee: Employee): Observable<Employee> {
    return this.httpClient.post<Employee>(`${this.employeesUrl}`, employee);
  }

  updateEmployee(employee: Employee): Observable<Employee> {
    return this.httpClient.put<Employee>(`${this.employeesUrl}/${employee.id}`, employee);
  }
}
