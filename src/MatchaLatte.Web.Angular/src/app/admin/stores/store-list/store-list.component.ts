import { AfterViewInit, Component, OnDestroy, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { finalize, startWith, switchMap, tap } from 'rxjs/operators';
import { PaginationResult } from 'src/app/core/pagination-result';
import { Store } from 'src/app/core/store/store';
import { StoreService } from 'src/app/core/store/store.service';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.scss']
})
export class StoreListComponent implements AfterViewInit, OnDestroy {
  isLoading = true;
  isEmptyResult = false;
  stores = new PaginationResult<Store>();
  dataSource = new MatTableDataSource<Store>();
  displayedColumns = ['rowId', 'name', 'createdOn', 'action'];

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  private subscription = new Subscription();

  constructor(private storeService: StoreService) { }

  ngAfterViewInit(): void {
    this.subscription.add(this.paginator.page
      .pipe(
        startWith({}),
        tap(() => this.isLoading = true),
        switchMap(() => this.storeService.getStores(this.paginator.pageIndex, this.paginator.pageSize)),
        tap(stores => {
          this.isLoading = false;
          this.isEmptyResult = stores.itemCount === 0;
          this.stores = stores;
          this.dataSource.data = stores.items;
        }),
        finalize(() => this.isLoading = false)
      )
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
