import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Order } from './order';
import { map } from 'rxjs/operators';
import { PaginationResult } from '../pagination-result';
import { Guid } from '../guid';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = 'ordering/api/orders';

  constructor(private httpClient: HttpClient) { }

  getOrders(groupId: Guid, pageIndex: number, pageSize: number): Observable<PaginationResult<Order>> {
    const params = new HttpParams()
      .set('gruopId', groupId.toString())
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient
      .get<Order[]>(this.ordersUrl, { params, observe: 'response' })
      .pipe(
        map(response => {
          const itemCount = +response.headers.get('X-Total-Count');
          return new PaginationResult<Order>(pageIndex, pageSize, itemCount, response.body);
        })
      );
  }

  getMyOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(`${this.ordersUrl}`);
  }

  createOrder(order: Order): Observable<Order> {
    return this.httpClient.post<Order>(`${this.ordersUrl}`, order);
  }
}
