import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Guid } from '../shared/guid';
import { PaginationResult } from '../shared/pagination-result';
import { Group } from './group';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private groupsUrl = 'ordering/api/groups';

  constructor(private httpClient: HttpClient) { }

  getGroups(pageIndex: number, pageSize: number): Observable<PaginationResult<Group>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient.get<Group[]>(this.groupsUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Total-Count');
        return new PaginationResult<Group>(pageIndex, pageSize, itemCount, response.body);
      })
    );
  }

  getGroup(id: Guid): Observable<Group> {
    return this.httpClient.get<Group>(`${this.groupsUrl}/${id}`);
  }

  getNewGroup(): Observable<Group> {
    return this.httpClient.get<Group>(`${this.groupsUrl}/new`);
  }

  createGroup(group: Group): Observable<Group> {
    return this.httpClient.post<Group>(`${this.groupsUrl}`, group);
  }

  updateGroup(group: Group): Observable<Group> {
    return this.httpClient.put<Group>(`${this.groupsUrl}/${group.groupId}`, group);
  }
}
