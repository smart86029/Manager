import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable, Injector, NgZone } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class AppErrorHandler implements ErrorHandler {
  constructor(private injector: Injector) { }

  handleError(error: any): void {
    const ngZone = this.injector.get(NgZone);
    const router = this.injector.get(Router);

    console.error(error);
    if (error instanceof HttpErrorResponse) {
      if (error.status === 401) {
        ngZone.run(() => router.navigate(['/auth/signin'], { queryParams: { returnUrl: router.url } })).then();
      }
    } else {
      router.navigate(['/error'], { queryParams: { error } });
    }
  }
}
