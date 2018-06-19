import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  log(msg: string): void {
    console.log(msg);
  }

  error(msg: string): void {
    console.error(msg);
  }
}
