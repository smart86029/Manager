import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private notification: BehaviorSubject<string> = new BehaviorSubject(null);

  constructor() { }

  notify(message) {
    this.notification.next(message);
    setTimeout(() => this.notification.next(null), 3000);
  }
}
