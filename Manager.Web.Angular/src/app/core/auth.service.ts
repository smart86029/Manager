import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, tap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LogService } from './log.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AuthService {
  private tokensUrl = 'api/tokens';
  redirectUrl: string;
  isauthorized = () => !this.jwtHelper.isTokenExpired();

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
      tap((token: string) => localStorage.setItem('access_token', token)),
      catchError(this.handleError('signIn', null))
    );
  }

  signOut(): void {
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
