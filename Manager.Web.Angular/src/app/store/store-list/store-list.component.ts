import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';

import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.scss']
})
export class StoreListComponent implements OnInit {
  displayedColumns = ['id', 'name', 'createdOn', 'action'];
  dataSource = new MatTableDataSource<Store>();
  pageSize = 10;
  itemCount = 0;

  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.getStores(0, this.pageSize);
  }

  private getStores(pageIndex: number, pageSize: number): void {
    this.storeService.getStores(pageIndex + 1, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.itemCount = result.itemCount;
      });
  }
}
