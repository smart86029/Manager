import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { LogService } from './log.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AuthService {
  redirectUrl: string;

  private tokensUrl = 'api/tokens';
  private tokenKey = 'access_token';

  constructor(
    private httpClient: HttpClient,
    private logService: LogService,
    private jwtHelper: JwtHelperService) { }

  signIn(userName: string, password: string): Observable<boolean> {
    const body = {
      UserName: userName,
      Password: password
    };

    return this.httpClient.post<string>(this.tokensUrl, body, httpOptions).pipe(
      tap(data => localStorage.setItem(this.tokenKey, data['token'])),
      catchError(this.handleError('signIn', null))
    );
  }

  signOut(): void {
    localStorage.removeItem(this.tokenKey);
  }

  isAuthorized(): boolean {
    const token = localStorage.getItem(this.tokenKey);

    return !this.jwtHelper.isTokenExpired(token);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
