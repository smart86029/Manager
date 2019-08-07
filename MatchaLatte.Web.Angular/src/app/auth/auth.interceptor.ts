import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector, NgZone } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, filter, switchMap, take, finalize } from 'rxjs/operators';

import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private isRefreshing = false;
  private refreshToken$: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(private injector: Injector) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> | any {
    const authService = this.injector.get(AuthService);
    const accessToken = authService.getAccessToken();
    if (accessToken) {
      request = this.addToken(request, accessToken);
    }

    return next
      .handle(request)
      .pipe(
        catchError(error => {
          if (error instanceof HttpErrorResponse && error.status === 401) {
            return this.handle401Error(request, next);
          } else {
            return throwError(error);
          }
        })
      );
  }

  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> | any {
    const authService = this.injector.get(AuthService);
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshToken$.next(null);
      if (!authService.getAccessToken()) {
        const ngZone = this.injector.get(NgZone);
        const router = this.injector.get(Router);
        ngZone.run(() => router.navigate(['/auth/signin'], { queryParams: { returnUrl: router.url } })).then();
      }

      return authService
        .refresh()
        .pipe(
          switchMap(() => {
            const accessToken = authService.getAccessToken();
            this.refreshToken$.next(accessToken);
            return next.handle(this.addToken(request, accessToken));
          }),
          catchError(() => {
            return authService.signOut() as any;
          }),
          finalize(() => {
            this.isRefreshing = false;
          }),
        );
    } else {
      this.isRefreshing = false;
      return this.refreshToken$
        .pipe(
          filter(accessToken => accessToken != null),
          take(1),
          switchMap(accessToken => {
            return next.handle(this.addToken(request, accessToken));
          })
        );
    }
  }
}
