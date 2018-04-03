import { Component, OnInit } from '@angular/core';
import { StoreService } from '../store.service';
import { Store } from '../store';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.scss']
})
export class StoreListComponent implements OnInit {
  displayedColumns = ['id', 'name', 'createdOn', 'action'];
  stores: Store[];

  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.getStores();
  }

  private getStores(): void {
    this.storeService.getStores()
      .subscribe(stores => this.stores = stores);
  }
}
