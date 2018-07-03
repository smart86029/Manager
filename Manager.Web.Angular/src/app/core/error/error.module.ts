import { CommonModule } from '@angular/common';
import { ErrorHandler, NgModule } from '@angular/core';

import { AppErrorHandler } from './app-error-handler';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
  ]
})
export class ErrorModule { }
