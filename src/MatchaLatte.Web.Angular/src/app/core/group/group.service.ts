import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Guid } from '../guid';
import { PaginationResult } from '../pagination-result';
import { Group } from './group';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private groupsUrl = 'catalog/api/groups';

  constructor(private httpClient: HttpClient) { }

  getGroups(pageIndex: number, pageSize: number): Observable<PaginationResult<Group>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());
    return this.httpClient
      .get<Group[]>(this.groupsUrl, { params, observe: 'response' })
      .pipe(
        map(response => {
          const itemCount = +response.headers.get('X-Total-Count');
          return new PaginationResult<Group>(pageIndex, pageSize, itemCount, response.body);
        })
      );
  }

  getActiveGroups(pageIndex: number, pageSize: number): Observable<PaginationResult<Group>> {
    const params = new HttpParams()
      .set('offset', '0')
      .set('limit', '10')
      .set('searchType', '1');
    return this.httpClient
      .get<Group[]>(this.groupsUrl, { params, observe: 'response' })
      .pipe(
        map(response => {
          const itemCount = +response.headers.get('X-Total-Count');
          return new PaginationResult<Group>(pageIndex, pageSize, itemCount, response.body);
        })
      );
  }

  getGroup(id: Guid): Observable<Group> {
    return this.httpClient.get<Group>(`${this.groupsUrl}/${id}`);
  }

  getNewGroup(storeId: Guid): Observable<Group> {
    const params = new HttpParams()
      .set('storeId', storeId.toString());
    return this.httpClient.get<Group>(`${this.groupsUrl}/new`, { params });
  }

  createGroup(group: Group): Observable<Group> {
    return this.httpClient.post<Group>(`${this.groupsUrl}`, group);
  }

  updateGroup(group: Group): Observable<Group> {
    return this.httpClient.put<Group>(`${this.groupsUrl}/${group.id}`, group);
  }
}
