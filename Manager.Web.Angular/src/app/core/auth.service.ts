import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LogService } from './log.service';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AuthService {
  private tokensUrl = 'api/tokens';
  isLoggedIn = false;
  redirectUrl: string;

  constructor(private httpClient: HttpClient, private logService: LogService) { }

  signIn(userName: string, password: string): Observable<boolean> {
    const body = {
      UserName: userName,
      Password: password
    };

    // return Observable.of(true).delay(1000).do(val => this.isLoggedIn = true);
    return this.httpClient.post<string>(this.tokensUrl, body, httpOptions).pipe(
      tap((token: string) => this.logService.log('signIn 201')),
      catchError(this.handleError('signIn', null))
    );
  }

  signOut(): void {
    this.isLoggedIn = false;
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
