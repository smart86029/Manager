import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';

import { LogService } from '../log.service';
import { NotificationService } from '../notification.service';

@Injectable()
export class AppErrorHandler implements ErrorHandler {
    constructor(private injector: Injector, private logService: LogService, private notificationService: NotificationService) { }

    handleError(error: any) {
        const router = this.injector.get(Router);

        this.logService.error(error);
        if (error instanceof HttpErrorResponse) {
            if (!navigator.onLine) {
                return this.notificationService.notify('網路錯誤');
            }

            return this.notificationService.notify(`${error.status} - ${error.message}`);
        } else {
            router.navigate(['/error'], { queryParams: { error: error } });
        }
    }
}
