import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Store } from './store';
import { PaginationResult } from '../shared/pagination-result';

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
      }),
      catchError(this.handleError('getStores', new PaginationResult<Store>()))
    );
  }

  getStore(id: number): Observable<Store> {
    return this.httpClient.get<Store>(`${this.storesUrl}/${id}`).pipe(
      catchError(this.handleError('getStore', null))
    );
  }

  getNewStore(): Observable<Store> {
    return of(new Store());
  }

  createStore(store: Store): Observable<Store> {
    return this.httpClient.post<Store>(`${this.storesUrl}`, store).pipe(
      catchError(this.handleError('createStore', store))
    );
  }

  updateStore(store: Store): Observable<Store> {
    return this.httpClient.put<Store>(`${this.storesUrl}/${store.storeId}`, store).pipe(
      catchError(this.handleError('updateStore', store))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}
