import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError } from 'rxjs/operators';

import { Role } from './role';

@Injectable()
export class RoleService {
  private rolesUrl = 'api/roles';

  constructor(private httpClient: HttpClient) { }

  getRoles(): Observable<Role[]> {
    return this.httpClient.get<Role[]>(this.rolesUrl).pipe(
      catchError(this.handleError('getRoles', []))
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
    return this.httpClient.put<Role>(`${this.rolesUrl}/${role.RoleId}`, role).pipe(
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
