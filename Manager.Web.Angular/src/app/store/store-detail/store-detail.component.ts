import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html',
  styleUrls: ['./store-detail.component.scss']
})
export class StoreDetailComponent implements OnInit {
  displayedColumns = ['name', 'price'];
  saveMode = SaveMode.Create;
  store = new Store();

  constructor(
    private storeService: StoreService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.saveMode = SaveMode.Update;
      this.storeService.getStore(id)
        .subscribe(store => this.store = store);
    } else {
      this.storeService.getNewStore()
        .subscribe(store => this.store = store);
    }
  }

  save(): void {
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  private create(): void {
    this.storeService.createStore(this.store)
      .subscribe(store => this.location.back());
  }

  private update(): void {
    this.storeService.updateStore(this.store)
      .subscribe(store => this.location.back());
  }
}
