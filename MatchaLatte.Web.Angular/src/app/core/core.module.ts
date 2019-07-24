import { CommonModule } from '@angular/common';
import { ErrorHandler, NgModule } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MomentDateAdapter } from '@coachcare/datepicker';

import { APP_DATE_FORMATS } from './app-date-formats';
import { AppErrorHandler } from './app-error-handler';
import { AppPaginatorIntl } from './app-paginator-intl';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
    { provide: MatPaginatorIntl, useClass: AppPaginatorIntl },
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2000 } },
  ],
})
export class CoreModule { }
