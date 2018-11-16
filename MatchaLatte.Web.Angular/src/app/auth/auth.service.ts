import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokensUrl = 'identity/api/token';
  private tokenKey = 'access_token';

  constructor(private httpClient: HttpClient, private jwtHelper: JwtHelperService) { }

  signIn(userName: string, password: string): Observable<boolean> {
    const body = {
      UserName: userName,
      Password: password
    };

    return this.httpClient.post(this.tokensUrl, body).pipe(
      tap(data => localStorage.setItem(this.tokenKey, data[this.tokenKey])),
      catchError(this.handleError('signIn', null))
    );
  }

  signOut(): void {
    localStorage.removeItem(this.tokenKey);
  }

  isAuthorized(): boolean {
    return !this.jwtHelper.isTokenExpired();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}