import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Guid } from '../shared/guid';
import { PaginationResult } from '../shared/pagination-result';
import { Permission } from './permission';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {
  private permissionsUrl = 'identity/api/permissions';

  constructor(private httpClient: HttpClient) { }

  getPermissions(pageIndex: number, pageSize: number): Observable<PaginationResult<Permission>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient.get<Permission[]>(this.permissionsUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Total-Count');
        return new PaginationResult<Permission>(pageIndex, pageSize, itemCount, response.body);
      })
    );
  }

  getPermission(id: Guid): Observable<Permission> {
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
