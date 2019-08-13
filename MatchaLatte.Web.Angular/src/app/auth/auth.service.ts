import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokensUrl = 'identity/api/token';
  private accessKey = 'access_token';
  private refreshKey = 'refresh_token';

  constructor(private httpClient: HttpClient) { }

  signIn(userName: string, password: string): Observable<void> {
    const body = {
      UserName: userName,
      Password: password,
    };
    return this.httpClient
      .post(this.tokensUrl, body)
      .pipe(
        tap(token => this.setToken(token)),
        map(() => { return; })
      );
  }

  signOut(): void {
    localStorage.removeItem(this.accessKey);
    localStorage.removeItem(this.refreshKey);
  }

  refresh(): Observable<void> {
    const body = {
      AccessToken: localStorage.getItem(this.accessKey),
      RefreshToken: localStorage.getItem(this.refreshKey),
    };
    return this.httpClient
      .post(`${this.tokensUrl}/refresh`, body)
      .pipe(
        tap(token => this.setToken(token)),
        map(() => { return; })
      );
  }

  isAuthorized(): boolean {
    const accessToken = this.getAccessToken();
    if (!accessToken) {
      return false;
    }

    const parts = accessToken.split('.');
    if (parts.length !== 3) {
      throw new Error('The inspected token doesn\'t appear to be a JWT.');
    }

    const decoded = atob(parts[1]);
    if (!decoded) {
      throw new Error('Cannot decode the token.');
    }

    const payload = JSON.parse(decoded);
    if (!payload || !payload.hasOwnProperty('exp')) {
      return true;
    }

    const date = new Date(0);
    date.setUTCSeconds(payload.exp);

    return new Date() < date;
  }

  getAccessToken(): string {
    return localStorage.getItem(this.accessKey);
  }

  private setToken(token: any): void {
    localStorage.setItem(this.accessKey, token[this.accessKey]);
    localStorage.setItem(this.refreshKey, token[this.refreshKey]);
  }

  private decodeAccessToken(): any {
    const accessToken = this.getAccessToken();
    if (accessToken == null || accessToken === '') {
      return null;
    }

    const parts = accessToken.split('.');
    if (parts.length !== 3) {
      throw new Error('The inspected token doesn\'t appear to be a JWT.');
    }

    const decoded = atob(parts[1]);
    if (!decoded) {
      throw new Error('Cannot decode the token.');
    }

    return JSON.parse(decoded);
  }
}
