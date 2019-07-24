import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Order } from './order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = 'ordering/api/orders';

  constructor(private httpClient: HttpClient) { }

  createOrder(order: Order): Observable<Order> {
    return this.httpClient.post<Order>(`${this.ordersUrl}`, order);
  }
}
