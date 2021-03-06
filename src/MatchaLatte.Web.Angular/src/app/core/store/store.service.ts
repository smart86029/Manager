import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { Guid } from '../guid';
import { PaginationResult } from '../pagination-result';
import { ProductCategory } from './product-category';
import { Store } from './store';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private storesUrl = 'catalog/api/stores';

  constructor(private httpClient: HttpClient) { }

  getStores(pageIndex: number, pageSize: number): Observable<PaginationResult<Store>> {
    const params = new HttpParams()
      .set('offset', (pageIndex * pageSize).toString())
      .set('limit', pageSize.toString());
    return this.httpClient
      .get<Store[]>(this.storesUrl, { params, observe: 'response' })
      .pipe(
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
    const store = new Store();
    const category = new ProductCategory();
    category.name = 'default';
    store.productCategories.push(category);
    return of(store);
  }

  createStore(store: Store): Observable<Store> {
    return this.httpClient.post<Store>(`${this.storesUrl}`, store);
  }

  updateStore(store: Store, logo: File): Observable<Store> {
    const formData = new FormData();
    formData.append('store', JSON.stringify(store));
    formData.append('logo', logo);
    return this.httpClient.put<Store>(`${this.storesUrl}/${store.id}`, formData);
  }
}
