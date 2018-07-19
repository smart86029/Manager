import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  log(msg: string): void {
    console.log(msg);
  }

  error(error: any): void {
    const date = new Date().toLocaleString();

    if (error instanceof HttpErrorResponse) {
      console.error(date, 'There was an HTTP error.', error.message, 'Status code:', error.status);
    } else if (error instanceof TypeError) {
      console.error(date, 'There was a Type error.', error.message);
    } else if (error instanceof Error) {
      console.error(date, 'There was a general error.', error.message, error.stack);
    } else {
      console.error(date, 'Nobody threw an Error but something happened!', error);
    }
  }
}
