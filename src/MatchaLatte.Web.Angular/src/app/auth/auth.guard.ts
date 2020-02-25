import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanLoad, Route, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.checkLogin(state.url);
  }

  canLoad(route: Route): boolean {
    const url = `/${route.path}`;
    if (!this.checkLogin(url)) {
      return false;
    }
    const permissions = route.data.permissions;
    if (!this.authService.hasPermission(permissions[0])) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }

  private checkLogin(url: string): boolean {
    if (this.authService.isAuthorized()) {
      return true;
    }
    this.authService
      .refresh()
      .pipe(
        map(() => true),
        catchError(() => this.router.navigate(['/auth/signin'], { queryParams: { returnUrl: url } }))
      )
      .subscribe();
  }
}
