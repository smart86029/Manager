import { CommonModule } from '@angular/common';
import { ErrorHandler, NgModule } from '@angular/core';

import { AppErrorHandler } from './app-error-handler';

@NgModule({
  imports: [
    CommonModule,
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
  ],
})
export class CoreModule { }
