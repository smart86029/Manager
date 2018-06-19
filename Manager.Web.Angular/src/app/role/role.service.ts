import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { PaginationResult } from '../core/pagination-result';
import { Role } from './role';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private rolesUrl = 'api/roles';

  constructor(private httpClient: HttpClient) { }

  getRoles(pageIndex: number, pageSize: number): Observable<PaginationResult<Role>> {
    const params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString());

    return this.httpClient.get<Role[]>(this.rolesUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Pagination');
        return new PaginationResult<Role>(itemCount, response.body)
      }),
      catchError(this.handleError('getRoles', new PaginationResult<Role>()))
    );
  }

  getRole(id: number): Observable<Role> {
    return this.httpClient.get<Role>(`${this.rolesUrl}/${id}`).pipe(
      catchError(this.handleError('getRole', null))
    );
  }

  createRole(role: Role): Observable<Role> {
    return this.httpClient.post<Role>(`${this.rolesUrl}`, role).pipe(
      catchError(this.handleError('updateRole', role))
    );
  }

  updateRole(role: Role): Observable<Role> {
    return this.httpClient.put<Role>(`${this.rolesUrl}/${role.roleId}`, role).pipe(
      catchError(this.handleError('updateRole', role))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}
