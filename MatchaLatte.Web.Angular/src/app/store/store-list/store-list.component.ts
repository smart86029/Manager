import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';

import { Store } from '../store';
import { StoreService } from '../store.service';
import { PaginationResult } from 'src/app/shared/pagination-result';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.scss']
})
export class StoreListComponent implements OnInit {
  isLoading = false;
  displayedColumns = ['id', 'name', 'createdOn', 'action'];
  dataSource = new MatTableDataSource<Store>();
  stores = new PaginationResult<Store>();

  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.getStores(0, this.stores.pageSize);
  }

  private getStores(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.storeService.getStores(pageIndex, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.stores = result;
      }, () => { }, () => this.isLoading = false);
  }
}
