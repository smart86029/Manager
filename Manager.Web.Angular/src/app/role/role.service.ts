import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, tap } from 'rxjs/operators';

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

  getRole(id: Number): Observable<Role> {
    return this.httpClient.get<Role>(`${this.rolesUrl}/${id}`).pipe(
      catchError(this.handleError('getRole', null))
    );
  }

  updateRole(role: Role): Observable<Role> {
    return this.httpClient.put<Role>(`${this.rolesUrl}/${role.RoleId}`, role).pipe(
      catchError(this.handleError('updateRole', role))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
