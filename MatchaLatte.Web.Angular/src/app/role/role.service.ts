import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { PaginationResult } from '../shared/pagination-result';
import { Role } from './role';
import { Guid } from '../shared/guid';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private rolesUrl = 'identity/api/roles';

  constructor(private httpClient: HttpClient) { }

  getRoles(pageIndex: number, pageSize: number): Observable<PaginationResult<Role>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient.get<Role[]>(this.rolesUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Total-Count');
        return new PaginationResult<Role>(pageIndex, pageSize, itemCount, response.body);
      })
    );
  }

  getRole(id: Guid): Observable<Role> {
    return this.httpClient.get<Role>(`${this.rolesUrl}/${id}`);
  }

  getNewRole(): Observable<Role> {
    return this.httpClient.get<Role>(`${this.rolesUrl}/new`);
  }

  createRole(role: Role): Observable<Role> {
    return this.httpClient.post<Role>(`${this.rolesUrl}`, role);
  }

  updateRole(role: Role): Observable<Role> {
    return this.httpClient.put<Role>(`${this.rolesUrl}/${role.roleId}`, role);
  }
}
