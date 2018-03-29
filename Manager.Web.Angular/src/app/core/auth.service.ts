import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, tap } from 'rxjs/operators';

import { LogService } from './log.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AuthService {
  private tokensUrl = 'api/tokens';
  isLoggedIn = true;
  redirectUrl: string;

  constructor(private httpClient: HttpClient, private logService: LogService) { }

  signIn(userName: string, password: string): Observable<boolean> {
    const body = {
      UserName: userName,
      Password: password
    };

    return this.httpClient.post<string>(this.tokensUrl, body, httpOptions).pipe(
      tap((token: string) => localStorage.setItem('access_token', token)),
      tap((token: string) => this.isLoggedIn = true),
      catchError(this.handleError('signIn', null))
    );
  }

  signOut(): void {
    this.isLoggedIn = false;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
