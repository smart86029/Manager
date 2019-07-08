import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { PaginationResult } from 'src/app/shared/pagination-result';

import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.scss']
})
export class StoreListComponent implements OnInit {
  isLoading = false;
  stores = new PaginationResult<Store>();
  dataSource = new MatTableDataSource<Store>();
  displayedColumns = ['rowId', 'name', 'createdOn', 'action'];

  constructor(private storeService: StoreService) { }

  ngOnInit(): void {
    this.loadStores(0, this.stores.pageSize);
  }

  loadStores(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.storeService
      .getStores(pageIndex, pageSize)
      .subscribe({
        next: stores => {
          this.stores = stores;
          this.dataSource.data = stores.items;
        },
        complete: () => this.isLoading = false
      });
  }
}
