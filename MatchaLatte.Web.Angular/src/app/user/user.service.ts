import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Guid } from '../shared/guid';
import { PaginationResult } from '../shared/pagination-result';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private usersUrl = 'identity/api/users';

  constructor(private httpClient: HttpClient) { }

  getUsers(pageIndex: number, pageSize: number): Observable<PaginationResult<User>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient
      .get<User[]>(this.usersUrl, { params: params, observe: 'response' })
      .pipe(
        map(response => {
          const itemCount = +response.headers.get('X-Total-Count');
          return new PaginationResult<User>(pageIndex, pageSize, itemCount, response.body);
        })
      );
  }

  getUser(id: Guid): Observable<User> {
    return this.httpClient.get<User>(`${this.usersUrl}/${id}`);
  }

  getNewUser(): Observable<User> {
    return this.httpClient.get<User>(`${this.usersUrl}/new`);
  }

  createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(`${this.usersUrl}`, user);
  }

  updateUser(user: User): Observable<User> {
    return this.httpClient.put<User>(`${this.usersUrl}/${user.id}`, user);
  }
}
