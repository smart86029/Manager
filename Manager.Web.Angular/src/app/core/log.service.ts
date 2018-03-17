import { Injectable } from '@angular/core';

@Injectable()
export class LogService {
  log(msg: string) {
    console.log(msg);
  }

  error(msg: string) {
    console.error(msg);
  }
}
