import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const url = state.url;

    return this.checkLogin(url);
  }

  private checkLogin(url: string): boolean {
    if (this.authService.isAuthorized()) {
      return true;
    }

    this.router.navigate(['/auth/signin'], { queryParams: { returnUrl: url } });

    return false;
  }
}
