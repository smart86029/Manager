import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Guid } from '../shared/guid';
import { PaginationResult } from '../shared/pagination-result';
import { Store } from './store';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private storesUrl = 'ordering/api/stores';

  constructor(private httpClient: HttpClient) { }

  getStores(pageIndex: number, pageSize: number): Observable<PaginationResult<Store>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());

    return this.httpClient.get<Store[]>(this.storesUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Total-Count');
        return new PaginationResult<Store>(pageIndex, pageSize, itemCount, response.body);
      })
    );
  }

  getStore(id: Guid): Observable<Store> {
    return this.httpClient.get<Store>(`${this.storesUrl}/${id}`);
  }

  getNewStore(): Observable<Store> {
    return this.httpClient.get<Store>(`${this.storesUrl}/new`);
  }

  createStore(store: Store): Observable<Store> {
    return this.httpClient.post<Store>(`${this.storesUrl}`, store);
  }

  updateStore(store: Store): Observable<Store> {
    return this.httpClient.put<Store>(`${this.storesUrl}/${store.storeId}`, store);
  }
}
