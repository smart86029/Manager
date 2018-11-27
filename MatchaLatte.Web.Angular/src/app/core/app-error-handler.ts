import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { Router, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AppErrorHandler implements ErrorHandler {
    constructor(private injector: Injector) { }

    handleError(error: any): void {
        const router = this.injector.get(Router);

        console.error(error);
        if (error instanceof HttpErrorResponse) {
            if (error.status === 401) {
                router.navigate(['/auth/signin'], { queryParams: { returnUrl: router.url }});
            }
        } else {
            router.navigate(['/error'], { queryParams: { error: error } });
        }
    }
}
