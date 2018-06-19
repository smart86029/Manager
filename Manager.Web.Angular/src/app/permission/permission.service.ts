import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { PaginationResult } from '../core/pagination-result';
import { Permission } from './permission';
import { PermissionModule } from './permission.module';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {
  private permissionsUrl = 'api/permissions';

  constructor(private httpClient: HttpClient) { }

  getPermissions(pageIndex: number, pageSize: number): Observable<PaginationResult<Permission>> {
    const params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString());

    return this.httpClient.get<Permission[]>(this.permissionsUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Pagination');
        return new PaginationResult<Permission>(itemCount, response.body);
      }),
      catchError(this.handleError('getPermissions', new PaginationResult<Permission>()))
    );
  }

  getPermission(id: number): Observable<Permission> {
    return this.httpClient.get<Permission>(`${this.permissionsUrl}/${id}`).pipe(
      catchError(this.handleError('getPermission', null))
    );
  }

  createPermission(permission: Permission): Observable<Permission> {
    return this.httpClient.post<Permission>(`${this.permissionsUrl}`, permission).pipe(
      catchError(this.handleError('updatePermission', permission))
    );
  }

  updatePermission(permission: Permission): Observable<Permission> {
    return this.httpClient.put<Permission>(`${this.permissionsUrl}/${permission.permissionId}`, permission).pipe(
      catchError(this.handleError('updatePermission', permission))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}
