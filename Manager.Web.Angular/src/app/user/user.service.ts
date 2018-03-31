import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError } from 'rxjs/operators';

import { User } from './user';

@Injectable()
export class UserService {
  private usersUrl = 'api/users';

  constructor(private httpClient: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.usersUrl).pipe(
      catchError(this.handleError('getUsers', []))
    );
  }

  getUser(id: Number): Observable<User> {
    return this.httpClient.get<User>(`${this.usersUrl}/${id}`).pipe(
      catchError(this.handleError('getUser', null))
    );
  }

  getNewUser(): Observable<User> {
    return this.httpClient.get<User>(`${this.usersUrl}/new`).pipe(
      catchError(this.handleError('getUser', null))
    );
  }

  createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(`${this.usersUrl}`, user).pipe(
      catchError(this.handleError('createUser', user))
    );
  }

  updateUser(user: User): Observable<User> {
    return this.httpClient.put<User>(`${this.usersUrl}/${user.UserId}`, user).pipe(
      catchError(this.handleError('updateUser', user))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}
