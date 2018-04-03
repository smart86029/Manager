import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from './store';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

@Injectable()
export class StoreService {
  private storesUrl = 'api/stores';

  constructor(private httpClient: HttpClient) { }

  getStores(): Observable<Store[]> {
    return this.httpClient.get<Store[]>(this.storesUrl).pipe(
      catchError(this.handleError('getStores', []))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}
